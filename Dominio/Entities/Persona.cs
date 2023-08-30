namespace Dominio.Entities;

public class Persona : BaseEntity
{
    

    public string NombrePersona { get; set; }
    public string ApellidoPersona { get; set; }
    public string DireccionPersona { get; set; }
    public int IdGeneroFk { get; set; }
    public Genero Genero { get; set; }
    public int IdCiudadFk { get; set; }
    public Ciudad Ciudad { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public TipoPersona TipoPersona { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }
    public ICollection<PersonaSalon> PersonaSalones { get; set; }


}
