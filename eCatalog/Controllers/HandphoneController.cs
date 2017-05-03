using eCatalog.Constants;
using eCatalog.DAL.HandphoneRepo;
using eCatalog.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCatalog.Controllers
{
    public class HandphoneController : Controller
    {
        HandphoneRepo handphoneRepo = new HandphoneRepo();

        // GET: Handphone
        public ActionResult Index(int PageIndex, long BrandID, int? MaxHarga, int? MinHarga)
        {
            //Controller untuk menampilkan page list of handphone
            //UI : Vindy
            //Code : Geraldo
            //abc
            int PageSize = 16;
            HandphoneIndexViewModel viewmodel = new HandphoneIndexViewModel();
            Sorting sorting = new Sorting();

            //Filtering Brand
            if (BrandID == 0)
            {
                viewmodel.Handphone = handphoneRepo.GetAll();
            }
            else
            {
                viewmodel.Handphone = handphoneRepo.GetbyBrand(handphoneRepo.GetAll(), BrandID);
            }

            //Filter by Price range
            viewmodel.Handphone = handphoneRepo.GetbyFilterPrice(viewmodel.Handphone, MinHarga, MaxHarga);

            viewmodel.PageCounts = (int)Math.Ceiling(Convert.ToDecimal(viewmodel.Handphone.Count / PageSize));
            viewmodel.PageIndex = PageIndex;
            viewmodel.Handphone = handphoneRepo.GetListforOnePage(viewmodel.Handphone, PageIndex, PageSize);

            return View(viewmodel);
        }

        public ActionResult Details(long id)
        {
            //Controller untuk menampilkan page detail handphone
            //UI: Vindy
            //Code : Geraldo

            handphoneRepo.AddViewer(id);
            var model = handphoneRepo.GetById(id);

            return View(model);
        }

    }
}