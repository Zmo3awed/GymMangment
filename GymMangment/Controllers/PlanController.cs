
using GymMangment.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GymMangment.Controllers

{

    public class PlanController : Controller
    {
        private GymContext context = new GymContext(); 
        public async Task<IActionResult> Index() 
        {
            var Plans = await context.Plans.ToListAsync();
             return View(Plans);
        }
        public async Task<IActionResult> ToggelStatus(int id) 
        {
            var plan = await context.Plans.FirstOrDefaultAsync(p=>p.Id == id);
            if (plan.IsActive) 
            {
                plan.IsActive = false;
            }
            else if (!plan.IsActive) 
            {
                plan.IsActive= true;

            }
           await context.SaveChangesAsync();
           return RedirectToAction("Index");


        }
    }
}
