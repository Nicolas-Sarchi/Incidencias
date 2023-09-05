using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly Incidenciascontext context;
    private PersonaRepository _personas;
    private DepartamentoRepository _departamentos;
    private PaisRepository _paises;
    private CiudadRepository _ciudades;

    public UnitOfWork(Incidenciascontext _context)
    {
        context = _context;
    }

    public IPersona Personas
    {
        get
        {
            if (_personas == null)
            {
                _personas = new PersonaRepository(context);
            }
            return _personas;
        }
    }

    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(context);
            }
            return _paises;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DepartamentoRepository(context);
            }
            return _departamentos;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(context);
            }
            return _ciudades;
        }
    }

    public async Task<int> SaveAsync()
    {
        return await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
    }
}
