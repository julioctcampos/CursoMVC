using GTAC.GTACAir.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTAC.GTACAir.Domain;
using GTAC.Repository.Interfaces;

namespace GTAC.GTACAir.Services.Impl.v1
{
    public class AircraftService : IAircraftService
    {
        IGTACGenericRepository<Aircraft, int> _aircraftRepository;

        public AircraftService(IGTACGenericRepository<Aircraft, int> aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        public List<Aircraft> Select()
        {
            return _aircraftRepository.SelectAll();
        }
    }
}
