using AutoMapper;
using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Web.Models;
using GTAC.GTACAir.Web.Models.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "DomainToViewModelProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<Aircraft, AircraftViewModel>()
                .ForMember(m => m.Model, opt => { opt.MapFrom(src => src.Model + " - " + src.Preffix); });

            Mapper.CreateMap<Crew, CrewViewModel>();

            Mapper.CreateMap<Component, ComponentViewModel>()
                .ForMember(m => m.AircraftName, opt => { opt.MapFrom(src => src.Aircraft.Model); });

            Mapper.CreateMap<Component, ComponentCUDViewModel>();
        }
    }
}