using Aplicacion.Repository;
using Dominio.Interfaces;
using Persistencia.Data;

namespace Aplicacion.UnitOfWork;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Incidenciascontext context;
        private PersonaRepository _personas;

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

        public int Save()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }

