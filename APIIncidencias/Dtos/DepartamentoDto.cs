using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;

namespace APIIncidencias.Dtos;

public class DepartamentoDto
{
    public int Id { get; set;}
    public string NombreDep{ get; set;}
    public List<CiudadDto> Ciudades{ get; set;}
}
