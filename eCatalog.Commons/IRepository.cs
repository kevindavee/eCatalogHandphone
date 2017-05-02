using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.Commons
{
    public interface IRepository<T>: IDisposable where T: Parent
    {
        void Save(T entity);
        void Delete(long id);
        T GetById(long id);
        List<T> GetAll();
        List<T> GetListforOnePage(List<T> list, int PageIndex, int PageSize);
    }
}
