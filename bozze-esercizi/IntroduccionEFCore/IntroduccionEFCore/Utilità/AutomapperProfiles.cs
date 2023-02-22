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
        }
    }
}
