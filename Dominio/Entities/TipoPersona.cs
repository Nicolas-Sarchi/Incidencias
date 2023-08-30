namespace Dominio.Entities;

public class TipoPersona : BaseEntity
{
    public string Descripcion { get; set; }
    public ICollection<Persona> Personas { get; set; }

}
