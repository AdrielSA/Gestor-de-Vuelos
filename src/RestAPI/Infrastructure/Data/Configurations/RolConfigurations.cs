using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class RolConfigurations : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            builder.HasKey(e => e.Codigo)
                    .HasName("PK_ROL");

            builder.Property(e => e.Codigo)
                .HasMaxLength(5)
                .IsUnicode(false);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
