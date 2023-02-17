using AutoMapper;
using Eliminar.DTOs;
using Eliminar.Entità;

namespace Eliminar.Utilidades
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<ScuolaCreacionDTO, Scuola>();
        }
    }
}
