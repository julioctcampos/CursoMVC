using AutoMapper;
using GTAC.GTACAir.WebApi.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.WebApi
{
    public class AutoMapperConfig
    {
        public static void RegisterAutoMapper()
        {
            Mapper.AddProfile<DomainToDTOProfile>();
            Mapper.AddProfile<DTOToDomainProfile>();
        }
    }
}