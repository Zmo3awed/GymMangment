using GymMangment.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangment.Configrations
{
    public class TrainerConfigration : GymUserConfigration<Trainer>, IEntityTypeConfiguration<Trainer>
    {
        public new void Configure (EntityTypeBuilder<Trainer> builder) 
        {
            builder.Property(x => x.CreatedAt).HasDefaultValueSql("GETDATE()");

            base.Configure(builder);

        }
    }
}
