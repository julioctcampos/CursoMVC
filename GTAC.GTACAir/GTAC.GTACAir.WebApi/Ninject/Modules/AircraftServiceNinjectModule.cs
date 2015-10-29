using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using Ninject.Modules;

namespace GTAC.GTACAir.WebApi.Modules
{
    public class AircraftServiceNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IAircraftService>().To<AircraftService>();
        }
    }
}