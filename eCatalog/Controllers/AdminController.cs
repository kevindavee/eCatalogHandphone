using eCatalog.Core.HandphoneClass;
using eCatalog.DAL.HandphoneRepo;
using eCatalog.ViewModel;
using eCatalog.ViewModel.AdminViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCatalog.Controllers
{
    public class AdminController : Controller
    {
        HandphoneRepo handphoneRepo = new HandphoneRepo();
        BrandRepo brandRepo = new BrandRepo();

        // GET: Admin
        public ActionResult Index()
        {
            //Controller untuk master page admin
            //UI: Vindy
            //Code: Dave
            AdminIndexViewModel viewmodel = new AdminIndexViewModel();
            viewmodel.Handphone.Handphone = handphoneRepo.GetListforOnePage(handphoneRepo.GetAll(), 0, 20);
            viewmodel.Handphone.PageCounts = (int)Math.Ceiling(Convert.ToDecimal(handphoneRepo.GetAll().Count() / 20));

            viewmodel.Brand.Brand = brandRepo.GetListforOnePage(brandRepo.GetAll(), 0, 20);
            viewmodel.Brand.PageCounts = (int)Math.Ceiling(Convert.ToDecimal(brandRepo.GetAll().Count / 20));

            return View(viewmodel);
        }
        public ActionResult nyoba()
        {
            return View();
        }
        public PartialViewResult ListOfHandphone(int PageIndex)
        {
            //Controller untuk return list of handphone
            //UI: Vindy
            //Code: Dave
            AdminHandphoneViewModel viewmodel = new AdminHandphoneViewModel();
            viewmodel.Handphone = handphoneRepo.GetListforOnePage(handphoneRepo.GetAll(), PageIndex, 20);
            viewmodel.PageCounts = (int)Math.Ceiling(Convert.ToDecimal(handphoneRepo.GetAll().Count / 20));
            
            return PartialView("_Handphone", viewmodel);
        }

        public PartialViewResult ListOfBrand(int PageIndex)
        {
            //Controller untuk return list of brand
            //UI: Vindy
            //Code: Dave

            AdminBrandViewModel viewmodel = new AdminBrandViewModel();
            viewmodel.Brand = brandRepo.GetAll();
            viewmodel.PageCounts = (int)Math.Ceiling(Convert.ToDecimal(viewmodel.Brand.Count / 20));

            return PartialView("_Brand", viewmodel);
        }
        
        public ActionResult Statistics()
        {
            //Controller untuk menampilkan page statistics
            //UI: Vindy
            //Code: Sindhu
            AdminStatisticsViewModel viewmodel = new AdminStatisticsViewModel();

            viewmodel.Handphone = handphoneRepo.GetbyMostSeen();
            return View(viewmodel);
        }

        public ActionResult AddHanphone(long id)
        {
            //Controller untuk menampilkan page add/edit product
            //UI: Vindy
            //Code : Sindhu

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHandphone([Bind(Include = "Id, BrandId, Name, ProductSpecification, SellPrice, BuyPrice")] Handphone handphone)
        {
            //Controller untuk proses add/edit product
            //Code : Sindhu
            try
            {
                if (ModelState.IsValid)
                {
                    handphoneRepo.Save(handphone);
                    return RedirectToAction("Index");
                }

                return View(handphone);
            }
            catch
            {
                return View(handphone);
            }
            
        }
        

        public ActionResult AddBrand()
        {
            //Controller untuk menampilkan page add/edit brand
            //UI: Vindy
            //Code: Sindhu
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBrand([Bind(Include ="Id, Name")]Brand brand)
        {
            //Controller untuk proses add/edit brand
            //UI : Vindy
            //Code: Sindhu
            
           try
            {
                if (ModelState.IsValid)
                {
                    brandRepo.Save(brand);
                    return RedirectToAction("Index");
                }
                return View(brand);
            }
            catch
            {
                return View(brand);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteHandphone(long id)
        {
            //Controller untuk proses delete handphone
            //Code: Geraldo
            handphoneRepo.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBrand(long id)
        {
            //Controller untuk proses delete brand
            //Code: Geraldo
            brandRepo.Delete(id);
            return RedirectToAction("Index");
        }

        public string SaveImage(HttpPostedFileBase upload)
        {
            string imageUrl = null;

            if (upload != null)
            {
                var fileName = "~/Images/Handphone" + Path.GetFileName(upload.FileName);

                upload.SaveAs(Server.MapPath(fileName));
                imageUrl = fileName;
            }

            return imageUrl;
        }
    }
}