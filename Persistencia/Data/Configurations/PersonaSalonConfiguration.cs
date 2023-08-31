using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configurations;

public class PersonaSalonConfiguration : IEntityTypeConfiguration<PersonaSalon>
{
    public void Configure(EntityTypeBuilder<PersonaSalon> builder)
    {
        builder.ToTable("persona_salon");

        builder.Property(g => g.IdPersonaFk).IsRequired();

        builder.Property(g => g.IdSalonFk).IsRequired();

        builder.HasOne(p => p.Persona)
        .WithMany(p => p.PersonaSalones)
        .HasForeignKey(p => p.IdPersonaFk);

        builder.HasOne(p => p.Salon)
        .WithMany(p => p.PersonaSalones)
        .HasForeignKey(p => p.IdSalonFk);
    }
}
