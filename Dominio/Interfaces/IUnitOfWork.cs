namespace Dominio.Interfaces;

public interface IUnitOfWork 
{
    IPersona Personas{ get; }
    IPais Paises{ get; }
    IDepartamento Departamentos{ get; }
    ICiudad Ciudades{ get; }

    Task<int> SaveAsync();
}
