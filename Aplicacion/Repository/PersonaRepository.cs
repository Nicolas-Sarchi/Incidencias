
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        protected readonly Incidenciascontext _context;

        public PersonaRepository(Incidenciascontext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Persona>> GetAllAsync()
        {
            return await _context.Personas.Include(p => p.Matriculas).ToListAsync();
            
        }

    }
}