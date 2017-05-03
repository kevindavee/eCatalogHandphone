using eCatalog.DAL.HandphoneRepo;
using eCatalog.ViewModel;
using eCatalog.ViewModel.HandphoneViewModel;
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
        public ActionResult Index(long BrandID)
        {
            //Controller untuk menampilkan page list of handphone
            //UI : Vindy
            //Code : Geraldo
            //abc
            HandphoneIndexViewModel viewmodel = new HandphoneIndexViewModel();

            viewmodel.BrandId = BrandID;

            return View(viewmodel);
        }

        public PartialViewResult IndexList(int PageIndex, int BrandID, int? MaxHarga, int? MinHarga, int sort)
        {
            HandphoneIndexListViewModel viewmodel = new HandphoneIndexListViewModel();
            int PageSize = 2;

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

            //Sorting
            viewmodel.Handphone = handphoneRepo.GetSorted(viewmodel.Handphone, sort);

            decimal counts = (decimal)viewmodel.Handphone.Count / PageSize;
            viewmodel.PageCounts = (int)Math.Ceiling(counts);
            viewmodel.PageIndex = PageIndex;
            viewmodel.Handphone = handphoneRepo.GetListforOnePage(viewmodel.Handphone, PageIndex, PageSize);

            return PartialView("_IndexList", viewmodel);
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