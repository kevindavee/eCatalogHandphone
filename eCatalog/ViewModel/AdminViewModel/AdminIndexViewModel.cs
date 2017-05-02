using eCatalog.Core.HandphoneClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCatalog.ViewModel.AdminViewModel
{
    public class AdminIndexViewModel
    {
        public AdminHandphoneViewModel Handphone { get; set; }
        public AdminBrandViewModel Brand { get; set; }

        public AdminIndexViewModel()
        {
            Handphone = new AdminHandphoneViewModel();
            Brand = new AdminBrandViewModel();
        }
    }
}