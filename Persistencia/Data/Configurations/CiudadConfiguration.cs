using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.Property(p => p.NombreCiudad).IsRequired().HasMaxLength(50);

        builder
            .HasOne(c => c.Departamento)
            .WithMany(c => c.Ciudades)
            .HasForeignKey(c => c.IdDeptoFk);
    }
}
