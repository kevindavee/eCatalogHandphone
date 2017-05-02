using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.DAL.HandphoneRepo
{
    public class HandphoneRepo: RepoBase<Handphone>
    {
        public override void Delete(long id)
        {
            var entity = GetById(id);
            entity.isDeleted = true;
            context.SaveChanges();
        }

        public List<Handphone> GetbyMostSeen()
        {
            return dbSet.OrderByDescending(s => s.Seen).ToListAsync().Result;
        }

        public List<Handphone> GetbyBrand(List<Handphone> list, long BrandId)
        {
            return list.Where(s => s.BrandId == BrandId).ToList();
        }

        public List<Handphone> GetbyFilterPrice(List<Handphone> list, int? min, int? max)
        {
            if (min != null)
            {
                list = list.Where(s => s.SellPrice >= min).ToList();
            }
            if (max != null)
            {
                list = list.Where(s => s.SellPrice <= max).ToList();
            }

            return list;
        }

        public override List<Handphone> GetAll()
        {
            return dbSet.OrderBy(o => o.Id).Include(i => i.Brand).ToListAsync().Result;
        }
        
        public void AddViewer(long id)
        {
            var entity = GetById(id);
            entity.Seen++;
            Save(entity);
        }

        public override void Save(Handphone handphone)
        {
            using (var contextTrans = context.Database.BeginTransaction())
            {
                try
                {
                    base.Save(handphone);
                    //Save Image Path
                    contextTrans.Commit();
                }
                catch (Exception)
                {
                    contextTrans.Rollback();
                    throw;
                }
            }
        }
    }
}
