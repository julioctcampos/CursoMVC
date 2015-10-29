using AutoMapper;
using GTAC.GTACAir.Domain;
using GTAC.GTACAir.WebApi.DTOs;

namespace GTAC.GTACAir.WebApi.AutoMapper
{
    public class DomainToDTOProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Aircraft, AircraftDTO>();
        }
    }
}