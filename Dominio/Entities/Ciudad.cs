namespace Dominio.Entities;

public class Ciudad : BaseEntity
{
    public string NombreCiudad { get; set; }

    public int IdDeptoFk { get; set; }

    public Departamento Departamento { get; set; }

    public ICollection<Persona> Personas { get; set; }

}
