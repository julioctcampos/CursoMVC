using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Repository.Entity.Impl.v1;
using GTAC.GTACAir.Services.Impl.v1;
using GTAC.GTACAir.Services.Impl.v1.Exceptions;
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
    public class ComponentServiceTests : IDisposable
    {
        private IGTACGenericRepository<Aircraft, int> _aircraftRepository;
        private IGTACGenericRepository<Component, int> _componentRepository;
        private IComponentService _componentService;
        private Mock<IGTACGenericRepository<Aircraft, int>> _aircraftRepositoryMock;
        private Mock<IGTACGenericRepository<Component, int>> _componentRepositoryMock;

        public ComponentServiceTests()
        {
            _aircraftRepositoryMock = new Mock<IGTACGenericRepository<Aircraft, int>>();
            _componentRepositoryMock = new Mock<IGTACGenericRepository<Component, int>>();

            _componentRepositoryMock.Setup(m => m.Insert(It.IsAny<Component>()));

            Aircraft aircraftWithLessThen3Components = new Aircraft
            {
                Components = new List<Component>()
            };
            aircraftWithLessThen3Components.Components.Add(new Component());
            _aircraftRepositoryMock.Setup(m => m.SelectByKey(1)).Returns(aircraftWithLessThen3Components);

            Aircraft aircraftWithMoreThen3Components = new Aircraft
            {
                Components = new List<Component>()
            };
            for (int i = 0; i < 4; i++)
                aircraftWithMoreThen3Components.Components.Add(new Component());
            _aircraftRepositoryMock.Setup(m => m.SelectByKey(2)).Returns(aircraftWithMoreThen3Components);

            _aircraftRepository = _aircraftRepositoryMock.Object;
            _componentRepository = _componentRepositoryMock.Object;
            _componentService = new ComponentService(_aircraftRepository, _componentRepository);
        }

        [Fact]
        public void AddComponentWithAircraftWithMoreThan3Components()
        {
            Assert.Throws<TooManyComponentsException>(() => 
            {
                Component component = new Component
                {
                    AircraftId = 2
                };
                _componentService.Insert(component);
                _aircraftRepositoryMock.Verify(m => m.SelectByKey(2));
            });
        }

        [Fact]
        public void AddComponentWithAircraftWithLessThan3Components()
        {
            Component component = new Component
            {
                AircraftId = 1
            };
            _componentService.Insert(component);
            _aircraftRepositoryMock.Verify(m => m.SelectByKey(1));
        }

        /*
        [Fact]
        public void TestSelect()
        {
            Assert.NotEmpty(_componentService.Select());
        }

        [Fact]
        public void TestInsertWithoutAircraft()
        {
            Assert.Throws<NullReferenceException>(() =>
            {
                Component component = new Component
                {
                    Manufacturer = "Embraer",
                    Title = "Teste Title"
                };
                _componentService.Insert(component);
            });
        }

        [Fact]
        public void TestInsert()
        {
            int before = _componentService.Select().Count;
            Aircraft a = _aircraftRepository.SelectAll().First();
            Component component = new Component
            {
                Manufacturer = "Embraer",
                Title = "Teste Title",
                AircraftId = a.Id
            };
            _componentService.Insert(component);
            int after = _componentService.Select().Count;
            Assert.Equal(after, before + 1);
        }
        */

        public void Dispose()
        {
            _componentService = null;
            _componentRepository = null;
            _aircraftRepository = null;
        }
    }
}
