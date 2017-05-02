using eCatalog.DAL.HandphoneRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCatalog.Controllers
{
    public class HomeController : Controller
    {
        BrandRepo brandRepo = new BrandRepo();

        public ActionResult Index()
        {
            //Controller untuk Home/Landing Page
            return View();
        }

        public PartialViewResult BrandMenu()
        {
            var model = brandRepo.GetAll();

            return PartialView("_BrandMenu", model);
        }
    }
}