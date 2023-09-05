using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIIncidencias.Dtos;

public class PersonaDto
{
    public int Id { get; set; }
    public string NombrePersona { get; set; }
    public string ApellidoPersona { get; set; }
    public int IdCiudadFk { get; set; }
    public int IdGeneroFk { get; set; }
    public int IdTipoPersonaFk { get; set; }
    public List<MatriculaDto> Matriculas { get; set; }
}
