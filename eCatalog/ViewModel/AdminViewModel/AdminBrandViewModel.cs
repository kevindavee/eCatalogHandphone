using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.ViewModel.AdminViewModel
{
    public class AdminBrandViewModel
    {
        public List<Brand> Brand { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageCounts { get; set; }
    }
}