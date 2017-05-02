using eCatalog.Commons;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.DAL
{
    public class RepoBase<T> : IRepository<T> where T : Parent
    {
        protected HandphoneContext context = new HandphoneContext();
        protected DbSet<T> dbSet;

        public RepoBase()
        {
            dbSet = context.Set<T>();
        }

        public virtual void Delete(long id)
        {
            var entity = GetById(id);
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual void Dispose()
        {
            context.Dispose();
        }

        public virtual List<T> GetAll()
        {
            return dbSet.OrderBy(e => e.Id).ToListAsync().Result;
        }

        public T GetById(long id)
        {
            return dbSet.Find(id);
        }

        public List<T> GetListforOnePage(List<T> list, int PageIndex, int PageSize)
        {
            return list.Skip(PageIndex * PageSize).Take(PageSize).ToList();
        }

        public virtual void Save(T entity)
        {
            if (entity.Id == 0)
            {
                dbSet.Add(entity);
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
