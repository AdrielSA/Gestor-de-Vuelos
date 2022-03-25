using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class VueloConfigurations : IEntityTypeConfiguration<Vuelo>
    {
        public void Configure(EntityTypeBuilder<Vuelo> builder)
        {
            builder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            builder.Property(e => e.Destino)
                    .IsRequired()
                    .HasMaxLength(30);

            builder.Property(e => e.Origen)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Partida).HasColumnType("date");

            builder.Property(e => e.Regreso).HasColumnType("date");

            builder.Property(e => e.UsuarioId).HasColumnName("UsuarioID");

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Vuelos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK_VUELO_USUARIO");
        }
    }
}
