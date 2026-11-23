using Microsoft.EntityFrameworkCore;
using GymMangment.Entityes;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangment.Configrations

{
    public class PlanConfigration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.HasMany(p => p.Supscripers)
                .WithOne(s => s.Plan)
                .OnDelete(DeleteBehavior.Restrict);
            builder.ToTable(t =>
            {
                t.HasCheckConstraint("chackDureation", "[DurationDays] between 1 and 365");
            });

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");

        }
    }
}
