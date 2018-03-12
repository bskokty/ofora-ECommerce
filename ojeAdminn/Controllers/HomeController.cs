using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oforadata.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace ojeAdminn.Controllers
{ 
    public class HomeController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: /Home/
        public ActionResult Index()
        {
            if (user == null)
            {
              
                return RedirectToAction("Login", "Account");

            }
            if (user.userName == "stokcu")
            {
                ViewBag.durum = "Stok Sorumlusu";

            }
            return View();
        }

        //
        [Display(Name = " ")]
        public ActionResult guncelle(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            category cat = datas.categories.Where(t=>t.Id==id).FirstOrDefault();
            ViewBag.mesaj = "Güncelle";
            return View(cat);
        }

        //
        [Display(Name = " ")]
        public ActionResult Categories()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<category> cat = datas.categories.ToList();
            return View(cat);
        }

        //
        [Display(Name = " ")]
        [HttpPost]
        public ActionResult Guncelle(int id,FormCollection collection)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            category cat = datas.categories.Where(t => t.Id == id).FirstOrDefault();
            cat.name = collection["name"].ToString();
     


            try
            {
                datas.SaveChanges();
                return RedirectToAction("Categories");
            }
            catch
            {
                return View(id);
            }
        }

        //
        [Display(Name = " ")]
        public ActionResult sil(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<product> a = datas.products.Where(x=> x.cId == id).ToList();
         
            foreach (var item in a)
            {
                datas.images.Remove(datas.images.Where(y => y.pid == item.Id).FirstOrDefault());
                datas.stockStatus.Remove(datas.stockStatus.Where(s => s.pId == item.Id).FirstOrDefault());
            }
            foreach (var item in a)
            {
                datas.products.Remove(datas.products.Where(z => z.Id ==item.Id).FirstOrDefault());
            }
            
            datas.categories.Remove(datas.categories.Where(q => q.Id == id).FirstOrDefault());
           
            datas.SaveChanges();
            return RedirectToAction("Categories");
        }

        //
        [Display(Name = " ")]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        [Display(Name = " ")]
        public ActionResult addd(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            category cat = new category();
            cat.name = frm["name"].ToString();

            datas.categories.Add(cat);

            try
            {
                datas.SaveChanges();
                return RedirectToAction("Categories");
            }
            catch
            {
                return View();
            }
        }
        [Display(Name=" ")]
        public ActionResult add()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            ViewBag.mesaj = "Ekle";
            return View("guncelle");
        }
        //
        [Display(Name = " ")]
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
