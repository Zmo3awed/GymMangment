using Microsoft.EntityFrameworkCore;
using GymMangment.Entityes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace GymMangment.Configrations
{
    public class MemberShipConfigration : IEntityTypeConfiguration<MemberShip>
    {
        public void Configure(EntityTypeBuilder<MemberShip> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(p => p.Member)
                .WithMany(m=>m.MemberSupscription)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Plan)
                .WithMany(p => p.Supscripers)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
        }
    }
}
