using GymMangment.Contexts;
using GymMangment.Entityes;
using GymMangment.Repository.IRepositry;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace GymMangment.Repository.Classes
{
    public class PlanRepositry : IPlanRepositry
    {
        //private GymContext _Context = new GymContext();
        /*
         * After Using DI You Cannot Able to use new ****
         
         */
        private readonly GymContext _Context;
        public PlanRepositry(GymContext context)
        {
            _Context = context; // You do not need to register it because he will get in here from relation with IPlanRepositry and here you need an object from the class it self no abstraction
        }
        public async Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken Token = default)
        {
            var plans = await _Context.Plans.AsNoTracking().ToListAsync(Token);
            return plans;

        }

        public async Task<Plan?> GetPlanByIdAsync(int id, CancellationToken Token = default)
        {
            var plan = await _Context.Plans.FindAsync([id],Token);
         
            return plan;
            
        }

        public async Task<int> SaveChangesAtPlanAsync(CancellationToken Token = default)
        {
            try
            {
                var saved = await _Context.SaveChangesAsync();
                return saved;
            }
            catch (Exception ex)
            {

                Console.WriteLine("Some Thing Happen Try Again");
                Console.WriteLine(ex.Message);
                return 0;
            }

        }
    }
}
