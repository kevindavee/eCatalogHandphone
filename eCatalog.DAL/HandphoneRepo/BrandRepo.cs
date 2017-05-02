using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCatalog.DAL.HandphoneRepo
{
    public class BrandRepo: RepoBase<Brand>
    {
        public List<Brand> GetAllOrderbyName()
        {
            return GetAll().OrderBy(o => o.Name).ToList();
        }
    }
}
