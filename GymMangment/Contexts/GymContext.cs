using Microsoft.EntityFrameworkCore;
using GymMangment.Entityes;
using System.Reflection;


namespace GymMangment.Contexts
{
    public class GymContext : DbContext
    {
        /*
         * You Can not Put Connection String At Your Code 
         */
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        //{
        //    optionsBuilder.UseSqlServer("Server=.;Database=Gym_Mangment;Trusted_Connection=True;TrustServerCertificate=True");

        //}
        public GymContext(DbContextOptions options) : base(options) { }
        


        

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<MemberShip> MemberShips { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
