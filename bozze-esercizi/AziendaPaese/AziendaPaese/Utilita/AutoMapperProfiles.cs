using AutoMapper;
using AziendaPaese.DTO;
using AziendaPaese.Entita;

namespace AziendaPaese.Utilita
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AziendaCreazioneDTO, Azienda>();
            CreateMap<RepartoCreazioneDTO, Reparto>();
        }
    }
}
