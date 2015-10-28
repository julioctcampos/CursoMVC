using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Interfaces;
using GTAC.Repository.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GTAC.GTACAir.Services.Test
{
    public class AircraftServiceTests : IDisposable
    {
        private IGTACGenericRepository<Aircraft, int> _aircraftRepository;
        private IAircraftService _aircraftService;
        private Mock<IGTACGenericRepository<Aircraft, int>> _aircraftRepositoryMock;

        public AircraftServiceTests()
        {
            _aircraftRepositoryMock = new Mock<IGTACGenericRepository<Aircraft, int>>();

            List<Aircraft> aircrafts = new List<Aircraft>();
            for (int i = 0; i < 5; i++)
                aircrafts.Add(new Aircraft());
            _aircraftRepositoryMock.Setup(m => m.SelectAll()).Returns(aircrafts);

            _aircraftRepository = _aircraftRepositoryMock.Object;
            _aircraftService = new AircraftService(_aircraftRepository);
        }

        [Fact]
        public void TestSelectAll()
        {
            Assert.NotEmpty(_aircraftRepository.SelectAll());
            _aircraftRepositoryMock.Verify(m => m.SelectAll());
        }

        public void Dispose()
        {
            _aircraftService = null;
            _aircraftRepository = null;
        }
    }
}
