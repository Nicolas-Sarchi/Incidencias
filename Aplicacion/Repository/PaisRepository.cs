using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dominio.Interfaces;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Persistencia.Data;

namespace Aplicacion.Repository
{
    public class PaisRepository : GenericRepository<Pais>, IPais
    {
        protected readonly Incidenciascontext _context;

        public PaisRepository(Incidenciascontext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises.Include(p => p.Departamentos).ThenInclude(d => d.Ciudades).ToListAsync();

        }
    }
}