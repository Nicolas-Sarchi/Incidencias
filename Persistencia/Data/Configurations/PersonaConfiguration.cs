using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PersonaConfiguration : IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");

        builder.Property(g => g.NombrePersona).IsRequired().HasMaxLength(50);

        builder.HasOne(p => p.Genero).WithMany(p => p.Personas).HasForeignKey(p => p.IdGeneroFk);

        builder.HasOne(p => p.Ciudad).WithMany(p => p.Personas).HasForeignKey(p => p.IdCiudadFk);

        builder.HasOne(p => p.TipoPersona).WithMany(p => p.Personas).HasForeignKey(p => p.IdTipoPersonaFk);
    }
}
