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
        }
    }
