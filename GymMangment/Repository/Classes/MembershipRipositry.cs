using GymMangment.Contexts;
using GymMangment.Entityes;
using GymMangment.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GymMangment.Repository.Classes
{
    public class MembershipRipositry : IMembershipRepositry
    {
        private readonly GymContext _Context;

        public MembershipRipositry(GymContext Context)
        {
            _Context = Context;
        }
        public async Task<bool> PlanHasAnyMembershipAsync(Expression<Func<MemberShip, bool>> predicate,CancellationToken Token)
        {
            var IsThereMembership = await _Context.MemberShips.AnyAsync(predicate, Token);
            return IsThereMembership;
        }
    }
}
