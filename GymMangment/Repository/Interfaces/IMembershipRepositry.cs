using GymMangment.Entityes;
using System.Linq.Expressions;

namespace GymMangment.Repository.Interfaces
{
    public interface IMembershipRepositry
    {
        Task<bool> PlanHasAnyMembershipAsync(Expression<Func<MemberShip, bool>> predicate, CancellationToken Token);


    }
}
