using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIIncidencias.Dtos;

public class CiudadDto
{
    public int Id { get; set; }
    public string NombreCiudad { get; set; }
    public List<PersonaDto> Personas { get; set; }
}
