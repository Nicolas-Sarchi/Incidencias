using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIIncidencias.Controllers;

public class PersonaController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;

    public PersonaController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Persona>>> Get()
    {
        var Personas = await unitOfWork.Personas.GetAllAsync();
        return Ok(Personas);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get(int id)
    {
        var Persona = await unitOfWork.Personas.GetByIdAsync(id);
        return Ok(Persona);
    }
}