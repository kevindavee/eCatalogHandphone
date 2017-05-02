using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.ViewModel.AdminViewModel
{
    public class AdminHandphoneViewModel
    {
        public List<Handphone> Handphone { get; set; }
        public int PageIndex { get; set; } = 0;
        public int PageCounts { get; set; }
    }
}