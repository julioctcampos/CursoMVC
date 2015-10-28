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

        public bool CanAddComponent(int aircraftId)
        {
            Aircraft aircraft = _aircraftRepository.SelectByKey(aircraftId);
            return !(aircraft.Components.Count > 3);
        }

        public void Insert(Component component)
        {
            if (CanAddComponent(component.AircraftId))
            {
                _componentRepository.Insert(component);
            }
            else
            {
                throw new TooManyComponentsException();
            }
        }

        public List<Component> Select()
        {
            return _componentRepository.SelectAll();
        }
    }
}
