using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Persistence.Entity.Context;
using GTAC.GTACAir.Repository.Entity.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Repository.Entity.Impl.v1
{
    public class AircraftRepositoryTAM
        : GTACAirGenericRepository<Aircraft, int>
    {
        public AircraftRepositoryTAM()
            : base(new GTACAirDbContext())
        {

        }

        public override List<Aircraft> SelectAll()
        {
            Aircraft[] aircrafts = _context.Set<Aircraft>().ToArray();
            for (int i = 0; i < aircrafts.Length; i++)
            {
                aircrafts[i].Model = aircrafts[i].Model + " - TAM";
            }
            return aircrafts.ToList();
        }
    }
}
