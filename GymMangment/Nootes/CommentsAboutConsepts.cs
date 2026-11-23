using GymMangment.Repository.Interfaces;
using GymMangment.Repository.IRepositry;

namespace GymMangment.Nootes
{
    public class CommentsAboutConsepts
    {
        #region Explaintion Of Repositry Pattern And Why Use It
        // you write [ var Plans = await context.Plans.ToListAsync(); ] every time you need to do some thing with data
        // this is violate "Do not Reabeat your self " 
        // so i need th have it once and could deal with it at all
        // Violate the S princable at SOLID 
        // this Class Handel Request Only Not All Request [He Only Make Connection Between View and Data] not deal with data and access
        // so i need aclass Deal with data to apply Single Responcabilty 

        #endregion
        #region Code Without Repositry Pattern

        //private GymContext context = new GymContext();
        //public async Task<IActionResult> Index()
        //{
        //    var Plans = await context.Plans.ToListAsync();
        //    return View(Plans);
        //}
        //public async Task<IActionResult> ToggelStatus(int id)
        //{
        //    var plan = await context.Plans.FirstOrDefaultAsync(p => p.Id == id);
        //    if (plan.IsActive)
        //    {
        //        plan.IsActive = false;
        //    }
        //    else if (!plan.IsActive)
        //    {
        //        plan.IsActive = true;

        //    }
        //    await context.SaveChangesAsync();
        //    context.Entry(plan).State = EntityState.Detached;
        //    return RedirectToAction("Index");


        //}
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var plan = await context.Plans.FindAsync(id);

        //    if (plan == null)
        //        return NotFound();

        //    return View(plan);
        //}
        //[HttpPost]
        //public async Task<IActionResult> Edit(Plan updatedPlan)
        //{
        //    // this Code Make You Update But There is a Problem
        //    // Supmetion More Than One Time Aloowed Thats Mean That You Hit The Action With Same Data Every Time 
        //    // I Fixed It By Check On the Values Befor Update 
        //    var plan = await context.Plans.FindAsync(updatedPlan.Id);
        //    if (plan.Name == updatedPlan.Name && plan.Description == updatedPlan.Description && plan.DurationDays == updatedPlan.DurationDays && plan.Price == updatedPlan.Price)
        //    {
        //        Ok(plan);
        //    }
        //    else
        //    {

        //        plan.Name = updatedPlan.Name;
        //        plan.Description = updatedPlan.Description;
        //        plan.Price = updatedPlan.Price;
        //        plan.DurationDays = updatedPlan.DurationDays;
        //        await context.SaveChangesAsync();
        //    }

        //    Console.WriteLine("Updated");
        //    return View(plan);


        //} 
        #endregion


        #region Comments
        //private readonly IPlanRepositry _Repo = new PlanRepositry(); 
        /* 
         * but here we create by our self and this is not good and we violate D at SOLID 
         * So We need to Use DI Pattern to make clr do it intade of us by this steps 
         * 1] write the ctor , method or prop that will use the object 
         * 2] go to program.cs to register the relation in services 
         
         */
        #endregion

        //Extra Info By ViewData["Key"] = "Value" --> Do not Forget to reseve it at Views
        //Use it only if you will send data for the same action not redirect action

        //Temp Data If Will Redirect To Onther request 
        // TempData["Key"] = "Value" Do not forget to use at views at View that you will redirect to it 
        // Store at cokiee and by deafult deleted after read it 
        // use TempData.Peek("Key") --> To Till CLR Do not delete it after reading 
        // use TempData.Keep("Key") --> To Till CLR Keep it for one more Request After Reading




        //public PlanController(IPlanRepositry Repo, IMembershipRepositry MembershipRepo)
        //{
        //    _Repo = Repo; //CLR Need to create object of planContriller and he find that we need to object from some thin implment IPlanRepositry
        //                  // So he will gonna do to see if this Relation Registerd If Yes Will Create An object From  THe Class That You Register it at Relation
        //    _MemberRepo = MembershipRepo;
        //}


        // you can not send object directly maybe some one send extra data by div tools 
        // we need to also make user know what the problem happend 
        // Solution to Use View Model
        // Z-Y-A-D //

    }
}
