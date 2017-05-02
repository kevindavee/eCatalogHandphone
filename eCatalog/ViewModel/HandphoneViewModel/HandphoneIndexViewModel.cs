using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.ViewModel
{
    public class HandphoneIndexViewModel
    {
        public List<Handphone> Handphone { get; set; }

        public int PageIndex { get; set; }

        public int PageCounts { get; set; }
    }
}