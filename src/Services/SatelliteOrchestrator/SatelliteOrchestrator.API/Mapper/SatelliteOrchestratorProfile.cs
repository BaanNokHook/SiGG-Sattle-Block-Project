using AutoMapper;
using SatelliteOrchestrator.API.Entities;
using Eventbus.Messages.Events;

namespace SatelliteOrchestrator.API.Mapper
{
    public class SatelliteOrchestratorProfile : Profile
    {
        public SatelliteOrchestratorProfile() 
        {
            CreateMap<SatelliteOrchestratorCheckout, SatelliteOrchestratorCheckoutEvent>().ReverseMap();
        }

    }
}
