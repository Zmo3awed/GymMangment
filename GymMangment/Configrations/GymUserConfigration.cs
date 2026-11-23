using GymMangment.Entityes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymMangment.Configrations
{
    public class GymUserConfigration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50);

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(11);

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x=>x.Phone).IsUnique();


            builder.ToTable(t =>
            {
                t.HasCheckConstraint("CheckEmailForm", "[Email] like '_%@_%._%'  ");
                t.HasCheckConstraint("CheckPhoneForm", "Phone like '010%' or Phone like '011%' or Phone like '012%' or Phone like '015%'");
                
            });
            builder.ComplexProperty(p => p.Address);



        }
    }
}
