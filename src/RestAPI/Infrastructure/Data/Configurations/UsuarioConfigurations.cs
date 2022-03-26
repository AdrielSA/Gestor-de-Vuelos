using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class UsuarioConfigurations : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            builder.Property(e => e.CodigoRol)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

            builder.Property(e => e.Contraseña).IsRequired();

            builder.HasIndex(e => e.Correo).IsUnique();

            builder.Property(e => e.Correo)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasOne(d => d.CodigoRolNavigation)
                .WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.CodigoRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_USUARIO_ROL");
        }
    }
}
