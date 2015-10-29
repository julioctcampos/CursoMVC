using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.Repository.Interfaces;
using Ninject.Modules;
using System.Configuration;

namespace GTAC.GTACAir.WebApi.Modules
{
    public class AircraftRepositoryNinjectModule
        : NinjectModule
    {
        public override void Load()
        {
            Bind<IGTACGenericRepository<Aircraft, int>>()
            .To<AircraftRepository>();
        }
    }
}