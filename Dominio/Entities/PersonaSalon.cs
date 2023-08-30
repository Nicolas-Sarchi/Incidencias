namespace Dominio.Entities;

public class PersonaSalon
{
    public int IdPersonaFk { get; set; }
    public Persona Persona{ get; set; }
    public int IdSalonFk { get; set; }
    public Salon Salon { get; set; }
}
