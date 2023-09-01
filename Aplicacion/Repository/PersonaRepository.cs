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
    public class PersonaRepository : GenericRepository<Persona>, IPersona
    {
        public PersonaRepository(Incidenciascontext context) : base(context)
        {
        }

    }
}