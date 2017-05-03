using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.ViewModel.HandphoneViewModel
{
    public class HandphoneIndexListViewModel
    {
        public List<Handphone> Handphone { get; set; }

        public int PageIndex { get; set; }

        public int PageCounts { get; set; }
    }
}