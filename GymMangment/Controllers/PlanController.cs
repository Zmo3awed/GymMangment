
using Microsoft.AspNetCore.Mvc;
using GymMangment.Repository.IRepositry;
using GymMangment.Repository.Interfaces;
using GymMangment.Entityes;
using GymMangment.ViewModels;
using System.Diagnostics.Eventing.Reader;

namespace GymMangment.Controllers

{
 

    public class PlanController : Controller
    {
  



        #region Code With Repositry Pattern
       
        private readonly IPlanRepositry _Repo;
        private readonly IMembershipRepositry _MemberRepo;
        public PlanController(IPlanRepositry Repo,IMembershipRepositry MembershipRepo)
        {
            _Repo = Repo; 
             _MemberRepo = MembershipRepo;
        }

        public async Task<IActionResult> Index(CancellationToken ct)
        {
    
            ViewData["Title"] = "Plans";
            var plans = await _Repo.GetAllPlansAsync();
            var ViewPlanModel = plans.Select(plans=> new PlanViewModel 
            {
                Id = plans.Id,
                Name = plans.Name,
                Description = plans.Description,
                DurationDays = plans.DurationDays,
                IsActive = plans.IsActive,
                Price = plans.Price,
            });
            return View(ViewPlanModel);

        }

        [HttpGet]
        public async Task<IActionResult> Edit([FromRoute]int id,CancellationToken ct) 
        {
            ViewData["Title"] = "Edit Plan";

            //Can not edit plan not in database
            var plan = await _Repo.GetPlanByIdAsync(id, ct);
            //Can not edit plan Has Active Membership
            var HasMembership = await _MemberRepo.PlanHasAnyMembershipAsync(m => m.planId == id && m.EndDate > DateTime.Now, ct);

            if (plan == null || !plan.IsActive || HasMembership)
            {


                TempData["ErrorMessage"] = "This Plan Can not Edit";
                return RedirectToAction(nameof(Index));
            }
            else
            {
                EditPlanViewModel viewModel = new EditPlanViewModel()
                {
                    Price = plan.Price,
                    PlanName = plan.Name,
                    Description = plan.Description,
                    DurationDays = plan.DurationDays,


                };
                return View(viewModel);
            }
            
         
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        // 1] View Data / TempData
        // 2] ModelState
        // 3] ViewModel
        public async Task<IActionResult> Edit([FromRoute]int id,EditPlanViewModel Updatedplan,CancellationToken ct) 
        {
            // Check on ModelState
            if (!ModelState.IsValid) return View(Updatedplan);



            // Check plan is exists and Active and if has AnyMemberShips 
            var plan = await _Repo.GetPlanByIdAsync(id, ct);
            var HasAnyMembership = await _MemberRepo.PlanHasAnyMembershipAsync(m=>m.planId == id && m.EndDate > DateTime.Now, ct);
            if(plan is null || HasAnyMembership || !plan.IsActive) 
            {
                TempData["ErrorMessage"] = "This Plan Can not Edit";
                return RedirectToAction(nameof(Index));

            }
            //if Ok 
            plan.Price = Updatedplan.Price;
            plan.Description = Updatedplan.Description;
            plan.DurationDays = Updatedplan.DurationDays;
            plan.UpdatedAt = DateTime.Now;

            var result = await _Repo.SaveChangesAtPlanAsync(ct) > 0;
            if (result) 
            {
                TempData["SucsessMessage"] = "Plan Updated Sucsessfuly";
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Plan Faild To Update");
                return View(nameof(Index));

            }

        



        }



        #endregion


    }
}
