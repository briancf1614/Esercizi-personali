using AutoMapper;
using IntroduccionEFCore.DTO;
using IntroduccionEFCore.Entità;

namespace IntroduccionEFCore.Utilità
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<DTOGenero, Genero>();
            CreateMap<DTOActor, Actor>();
            CreateMap<DTOPelicula, Pelicula>()
                .ForMember(ent => ent.Generos, dto => 
                dto.MapFrom(campo => campo.Generos.Select(id => new Genero { Id = id })));
            CreateMap<PeliculaActorDTO, PeliculaActor>();
        }
    }
}
