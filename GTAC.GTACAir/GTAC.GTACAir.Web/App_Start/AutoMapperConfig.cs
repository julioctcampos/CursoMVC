using AutoMapper;
using GTAC.GTACAir.Web.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            Mapper.AddProfile<DomainToViewModelProfile>();
            Mapper.AddProfile<ViewModelToDomainProfile>();
        }
    }
}