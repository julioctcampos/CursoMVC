using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.Repository.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GTAC.GTACAir.Web.Ninject.Modules
{
    public class ComponentRepositoryNinjectModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IGTACGenericRepository<Component, int>>()
                .To<ComponentRepository>();
        }
    }
}