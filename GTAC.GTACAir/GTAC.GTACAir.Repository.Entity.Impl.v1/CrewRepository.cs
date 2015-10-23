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
    public class CrewRepository
        : GTACAirGenericRepository<Crew, int>
    {
        public CrewRepository()
            : base(new GTACAirDbContext())
        {

        }
    }
}
