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
    public class ViewModelToDomainProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ViewModelToDomainProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<AircraftViewModel, Aircraft>();
            Mapper.CreateMap<CrewViewModel, Crew>();
            Mapper.CreateMap<ComponentCUDViewModel, Component>();
        }
    }
}