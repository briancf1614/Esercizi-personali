using AutoMapper;
using PianetaPersone.DTOs;
using PianetaPersone.Entity;

namespace PianetaPersone.AutoMapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        protected AutoMapperProfiles()
        {
            CreateMap<DTOPianeta, Pianeta>();
            CreateMap<DTOPersona, Persona>();
        }
    }
}
