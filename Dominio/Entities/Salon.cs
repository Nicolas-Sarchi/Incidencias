namespace Dominio.Entities;

public class Salon : BaseEntity
{
    public string NombreSalon { get; set; }
    public int Capacidad { get; set; }

    public ICollection<Matricula> Matriculas { get; set; }

    public ICollection<PersonaSalon> PersonaSalones { get; set; }


}
