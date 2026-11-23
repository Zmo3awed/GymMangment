using GymMangment.Entityes;

namespace GymMangment.Repository.IRepositry
{
    public interface IPlanRepositry
    {
         Task<IEnumerable<Plan>> GetAllPlansAsync(CancellationToken Token =default );
         Task<Plan?>GetPlanByIdAsync(int id,CancellationToken Token =default );
        Task<int> SaveChangesAtPlanAsync(CancellationToken Token = default);
        
          
        
    }
}
