using GymMangment.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangment.Configrations

{
    public class MemberConfigration : GymUserConfigration<Member>,IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(p => p.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            

             
            base.Configure(builder);

        }
    }
}
