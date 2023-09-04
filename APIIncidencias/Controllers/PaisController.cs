using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using APIIncidencias.Dtos;
using APIIncidencias.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIIncidencias.Controllers;

[ApiVersion("1.0")]
[ApiVersion("1.1")]

public class PaisController : BaseApiController
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper _mapper;

    public PaisController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [MapToApiVersion("1.0")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PaisDto>>> Get()
    {
        var Paises = await unitOfWork.Paises.GetAllAsync();
        return _mapper.Map<List<PaisDto>>(Paises);
    }

    [HttpGet]
    [MapToApiVersion("1.1")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Pager<PaisXDepDto>>> Get11([FromQuery] Params paisParams)
    {
        var pais = await unitOfWork.Paises.GetAllAsync(paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
        var lstPaisesDto = _mapper.Map<List<PaisXDepDto>>(pais.registros);
        return new Pager<PaisXDepDto>(lstPaisesDto, pais.totalRegistros, paisParams.PageIndex, paisParams.PageSize, paisParams.Search);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PaisDto>> Get(int id)
    {
        var Pais = await unitOfWork.Paises.GetByIdAsync(id);
        return _mapper.Map<PaisDto>(Pais);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<Pais>> Post(PaisDto PaisDto)
    {

        var Pais = _mapper.Map<Pais>(PaisDto);
        this.unitOfWork.Paises.Add(Pais);
        await unitOfWork.SaveAsync();

        if (Pais == null)
        {
            return BadRequest();
        }
        PaisDto.Id = Pais.Id;
        return CreatedAtAction(nameof(Post), new { id = PaisDto.Id }, PaisDto);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]

    public async Task<ActionResult<PersonaDto>> Put(int id, [FromBody] PersonaDto personaDto)
    {
        if (personaDto == null)
        {
            return NotFound();
        }
        var personas = _mapper.Map<Persona>(personaDto);
        unitOfWork.Personas.Update(personas);
        await unitOfWork.SaveAsync();
        return personaDto;
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]

    public async Task<IActionResult> Delete(int id)
    {
        var persona = await unitOfWork.Personas.GetByIdAsync(id);
        if (persona == null)
            return NotFound();

        unitOfWork.Personas.Remove(persona);
        await unitOfWork.SaveAsync();
        return NoContent();
    }


}