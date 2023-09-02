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
    public class DepartamentoRepository : GenericRepository<Departamento>, IDepartamento
    {
        protected readonly Incidenciascontext _context;

        public DepartamentoRepository(Incidenciascontext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Departamento>> GetAllAsync()
        {
            return await _context.Departamentos.Include(p => p.Ciudades).ToListAsync();

        }
    }
}