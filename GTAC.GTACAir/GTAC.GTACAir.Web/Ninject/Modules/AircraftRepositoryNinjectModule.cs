using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.Repository.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Ninject.Modules
{
    public class AircraftRepositoryNinjectModule
        : NinjectModule
    {
        public override void Load()
        {
            if (ConfigurationManager.AppSettings["Client"].ToString().Equals("TAM"))
            {
                Bind<IGTACGenericRepository<Aircraft, int>>()
                .To<AircraftRepositoryTAM>();
            }
            else
            {
                Bind<IGTACGenericRepository<Aircraft, int>>()
                .To<AircraftRepository>();
            }
        }
    }
}