using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Persistencia.Data.Configurations;

public class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");

        builder.Property(e => e.NombreDep).IsRequired().HasMaxLength(50);

        builder.HasOne(p => p.Pais).WithMany(p => p.Departamentos).HasForeignKey(p => p.IdPaisFk);
        
    }
}
