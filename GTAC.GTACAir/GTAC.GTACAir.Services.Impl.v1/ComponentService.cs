using GTAC.GTACAir.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTAC.GTACAir.Domain;
using GTAC.Repository.Interfaces;
using GTAC.GTACAir.Services.Impl.v1.Exceptions;

namespace GTAC.GTACAir.Services.Impl.v1
{
    public class ComponentService : IComponentService
    {
        IGTACGenericRepository<Aircraft, int> _aircraftRepository;
        IGTACGenericRepository<Component, int> _componentRepository;

        public ComponentService(IGTACGenericRepository<Aircraft, int> aircraftRepository,
            IGTACGenericRepository<Component, int> componentRepository)
        {
            _aircraftRepository = aircraftRepository;
            _componentRepository = componentRepository;
        }

        public void Insert(Component component)
        {
            Aircraft aircraft = _aircraftRepository.SelectByKey(component.AircraftId);
            if (aircraft.Components.Count < 3)
            {
                _componentRepository.Insert(component);
            }
            else
            {
                throw new TooManyComponentsException(aircraft.Components.Count);
            }
        }

        public List<Component> Select()
        {
            return _componentRepository.SelectAll();
        }
    }
}
