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
    public class ComponentRepository
        : GTACAirGenericRepository<Component, int>
    {
        public ComponentRepository()
            : base(new GTACAirDbContext())
        {

        }

        public override List<Component> SelectAll()
        {
            return _context.Set<Component>()
                .Include(p => p.Aircraft).ToList();
        }

        public override Component SelectByKey(int key)
        {
            return _context.Set<Component>()
                .Include(p => p.Aircraft)
                .SingleOrDefault(s => s.Id == key);
        }
    }
}
