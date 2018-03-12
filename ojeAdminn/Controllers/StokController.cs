using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ojeAdminn.Controllers
{
    public class StokController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Stok
        public ActionResult Index()
        {
            List<product> pr = datas.products.ToList();

            return View(pr);
        }

        // GET: Stok/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Stok/Create
        public ActionResult Create()
        {
            List<product> pr = datas.products.ToList();

            return View(pr);
        }

        // POST: Stok/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            try
            {
                stockStatu stk = new stockStatu();
                stk.pId = Convert.ToInt32(frm["urunsec"]);
                datas.stockStatus.Add(stk);
                datas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Stok/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Stok/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
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

        // GET: Stok/Delete/5
        public ActionResult Delete(int id)
        {

         


            int a = datas.stockStatus.Where(x => x.pId == id).Max(q => q.Id);
            datas.stockStatus.Remove(datas.stockStatus.Where(t => t.Id == a).FirstOrDefault());
            int d = (datas.products.Where(s => s.Id == id).FirstOrDefault().stockStatus);
            datas.products.Where(s => s.Id == id).FirstOrDefault().stockStatus = d - 1;
            datas.SaveChanges();
            return RedirectToAction("Index");

        }

        // POST: Stok/Delete/5
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
