using GymMangment.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymMangment.Configrations

{
    public class SessionConfigration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.HasOne(s => s.Trainer)
                .WithMany(t => t.Sessions)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CheckCapacity", "[Capacity] between 1 and 25");
                t.HasCheckConstraint("CheckEndDate", "[EndDate] > StartDate");
            });



        }
    }
}
