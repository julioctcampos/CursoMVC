using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using GTAC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GTAC.GTACAir.Services.Test
{
    public class ComponentServiceTests
    {
        [Fact]
        public void TestSelect()
        {
            IGTACGenericRepository<Aircraft, int> aircraftRepository = new AircraftRepository();
            IGTACGenericRepository<Component, int> componentRepository = new ComponentRepository();
            IComponentService componentService = new ComponentService(aircraftRepository, componentRepository);
            Assert.NotEmpty(componentService.Select());
        }
    }
}
