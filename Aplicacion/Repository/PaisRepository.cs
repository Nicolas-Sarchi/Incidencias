using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        protected readonly Incidenciascontext _context;

        public PaisRepository(Incidenciascontext context)
            : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises
                .Include(p => p.Departamentos)
                .ThenInclude(d => d.Ciudades)
                .ToListAsync();
        }

        public override async Task<(int totalRegistros, IEnumerable<Pais> registros)> GetAllAsync(
            int pageIndex,
            int pageSize,
            string search
        )
        {
            var query = _context.Paises as IQueryable<Pais>;
            if (!String.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.NombrePais.ToLower().Contains(search));
            }
            query = query.OrderBy(p => p.Id);
            var totalRegistros = await query.CountAsync();
            var registros = await query
                .Include(u => u.Departamentos)
                .ThenInclude(d => d.Ciudades)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (totalRegistros, registros);
        }
    }
}
