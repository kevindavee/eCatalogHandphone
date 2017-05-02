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
        public ActionResult IndexHandphone()
        {
            //Controller untuk master page admin
            //UI: Vindy
            //Code: Dave
            var model = handphoneRepo.GetAll();

            return View(model);
        }

        public ActionResult IndexBrand()
        {
            var model = brandRepo.GetAll();

            return View(model);
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

        public ActionResult AddHandphone(long id)
        {
            //Controller untuk menampilkan page add/edit product
            //UI: Vindy
            //Code : Sindhu
            Handphone model;
            ViewBag.Brand = new SelectList(brandRepo.GetAllOrderbyName(), "Id", "Name");

            if (id == 0)
            {
                model = new Handphone();
            }
            else
            {
                model = handphoneRepo.GetById(id);
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHandphone([Bind(Include = "Id, BrandId, Name, ProductDescription, SellPrice, BuyPrice")] Handphone handphone, HttpPostedFileBase upload)
        {
            //Controller untuk proses add/edit product
            //Code : Sindhu
            try
            {
                if (ModelState.IsValid)
                {
                    if (upload != null)
                    {
                        handphone.ImageUrl = SaveImage(upload);
                    }
                    handphoneRepo.Save(handphone);
                    return RedirectToAction("IndexHandphone");
                }
                ViewBag.Brand = new SelectList(brandRepo.GetAllOrderbyName(), "Id", "Name");
                return View(handphone);
            }
            catch
            {
                ViewBag.Brand = new SelectList(brandRepo.GetAllOrderbyName(), "Id", "Name");
                return View(handphone);
            }
            
        }
        

        public ActionResult AddBrand(long id)
        {
            //Controller untuk menampilkan page add/edit brand
            //UI: Vindy
            //Code: Sindhu

            Brand model;
            if (id == 0)
            {
                model = new Brand();
            }
            else
            {
                model = brandRepo.GetById(id);
            }
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
                    return RedirectToAction("IndexBrand");
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
            return RedirectToAction("IndexHandphone");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBrand(long id)
        {
            //Controller untuk proses delete brand
            //Code: Geraldo
            brandRepo.Delete(id);
            return RedirectToAction("IndexBrand");
        }

        public string SaveImage(HttpPostedFileBase upload)
        {
            string imageUrl = null;

            if (upload != null)
            {
                var fileName = "~/Images/Handphone/" + Path.GetFileName(upload.FileName);

                upload.SaveAs(Server.MapPath(fileName));
                imageUrl = fileName;
            }

            return imageUrl;
        }
    }
}