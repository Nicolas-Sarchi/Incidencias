using APIIncidencias.Dtos;
using AutoMapper;
using Dominio.Entities;

namespace APIIncidencias.Profiles;

    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
        CreateMap<Persona, PersonaDto>().ReverseMap();
        CreateMap<Matricula, MatriculaDto>().ReverseMap();
        CreateMap<Ciudad, CiudadDto>().ReverseMap();
        CreateMap<Departamento, DepartamentoDto>().ReverseMap();
        CreateMap<Pais, PaisDto>().ReverseMap();
        CreateMap<Pais, PaisXDepDto>().ReverseMap();

    }
}
