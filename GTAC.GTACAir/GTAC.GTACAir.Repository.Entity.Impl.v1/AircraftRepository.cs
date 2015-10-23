using GTAC.GTACAir.Domain;
using GTAC.GTACAir.Persistence.Entity.Context;
using GTAC.GTACAir.Repository.Entity.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace GTAC.GTACAir.Repository.Entity.Impl.v1
{
    public class AircraftRepository
        : GTACAirGenericRepository<Aircraft, int>
    {
        public AircraftRepository()
            : base(new GTACAirDbContext())
        {

        }

        public override Aircraft SelectByKey(int key)
        {
            return _context.Set<Aircraft>().Include(p => p.Components)
                .Where(w => w.Id == key).SingleOrDefault();
        }
    }
}
