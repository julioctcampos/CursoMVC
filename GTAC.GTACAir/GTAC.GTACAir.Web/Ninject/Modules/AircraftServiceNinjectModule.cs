﻿using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Ninject.Modules
{
    public class AircraftServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAircraftService>().To<AircraftService>();
        }
    }
}