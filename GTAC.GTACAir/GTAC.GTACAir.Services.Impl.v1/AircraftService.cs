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

        public void Delete(int aircraftId)
        {
            _aircraftRepository.DeleteByKey(aircraftId);
        }

        public void Insert(Aircraft aircraft)
        {
            _aircraftRepository.Insert(aircraft);
        }

        public List<Aircraft> Select()
        {
            return _aircraftRepository.SelectAll();
        }

        public Aircraft SelectById(int aircraftId)
        {
            return _aircraftRepository.SelectByKey(aircraftId);
        }

        public void Update(Aircraft aircraft)
        {
            _aircraftRepository.Update(aircraft);
        }
    }
}
