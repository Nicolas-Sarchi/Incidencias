namespace Dominio.Interfaces;

public interface IUnitOfWork 
{
    IPersona Personas{ get; }

    Task<int> SaveAsync();
}
