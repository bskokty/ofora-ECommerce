using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ojeAdminn.Controllers
{
    public class KullaniciController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Kullanici
        public ActionResult Index()
        {
            List<User> uu = datas.Users.Where(a=>a.ustatus==3).ToList();
            return View(uu);
        }

        // GET: Kullanici/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Kullanici/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kullanici/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Edit/5
        public ActionResult Edit(int id)
        {
            User cat = datas.Users.Where(t => t.Id == id).FirstOrDefault();


            return View(cat);
        }

        // POST: Kullanici/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {

            User cat = datas.Users.Where(t => t.Id == id).FirstOrDefault();
            cat.onayDurumu = Convert.ToInt32(frm["basliksec"]);

            try
            {
                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Delete/5
        public ActionResult Delete(int id)
        {
            datas.Users.Remove(datas.Users.Where(y => y.Id == id).FirstOrDefault());
            datas.SaveChanges();
            return View();
        }

        // POST: Kullanici/Delete/5
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
