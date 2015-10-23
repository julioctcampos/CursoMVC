using GTAC.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAC.GTACAir.Repository.Entity.Generic
{
    public class GTACAirGenericRepository<TEntity, TKey>
        : IGTACGenericRepository<TEntity, TKey>
        where TEntity : class
    {
        protected DbContext _context;

        public GTACAirGenericRepository(DbContext context)
        {
            _context = context;
        }

        public virtual List<TEntity> SelectAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity SelectByKey(TKey key)
        {
            return _context.Set<TEntity>().Find(key);
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public virtual void DeleteByKey(TKey key)
        {
            TEntity entity = SelectByKey(key);
            if (entity != null)
                Delete(entity);
        }
    }
}
