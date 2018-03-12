using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ojeAdminn.Models;

namespace ojeAdminn.Controllers
{
    public class BasketController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Basket
        public ActionResult Index()
        {    //daha sonra linq cozumu bul
            //***
            List<basket> qsk = datas.baskets.Where(u=>u.odeme==1).ToList();
            List<basket> bsk = new List<basket>();
            for (int i = 0; i < qsk.Count; i++)
            {
                if (i == 0)
                {
                    bsk.Add(qsk[0]);
                }
                else if (qsk[i].basketId != qsk[i-1].basketId)
                {
                    bsk.Add(qsk[i]);
                }
            }
            

             

            return View(bsk);
        }

        // GET: Basket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Basket/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Basket/Create
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

        // GET: Basket/Edit/5
        public ActionResult Edit(int id)
        {
            BasketViewModel bvm = new BasketViewModel();
            int bask = datas.baskets.Where(a => a.id == id).FirstOrDefault().basketId;
            int ask = datas.baskets.Where(a => a.id == id).FirstOrDefault().uid;
            List<basket> bsk = datas.baskets.Where(x => x.basketId == bask).ToList();
            bvm.baskk = bsk;
            bvm.idd = bask;
            bvm.ad = datas.Users.Where(a => a.Id == ask).FirstOrDefault().userName;
            decimal f = 0;
            foreach (var item in bsk)
            {
                f = f+item.price;
            }
            bvm.fiyat = f;
            return View(bvm);
        }

        // POST: Basket/Edit/5
        [HttpPost]
        public ActionResult Edit(int idd, FormCollection frm)
        {
            List<basket> qsk = datas.baskets.Where(c=>c.basketId==idd).ToList();
            try
            {
                foreach (var item in qsk)
                {
                    item.onay = Convert.ToInt32(frm["basliksec"]);
                 
                }
                datas.SaveChanges();

                if (Convert.ToInt32(frm["basliksec"])==1)
                {
                    order ordr = new order();
                    ordr.date = DateTime.Now;
                    ordr.uid = datas.baskets.Where(c => c.basketId == idd).FirstOrDefault().uid;
                    ordr.status = 1;
                    datas.orders.Add(ordr);
                    datas.SaveChanges();
                    
               
                    foreach (var item in qsk)
                    {
                        orderItem or = new orderItem();
                        or.oid = datas.orders.Max(u => u.id);
                        or.pid = item.pid;
                        or.piece = item.price;
                        datas.orderItems.Add(or);
                        datas.SaveChanges();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Basket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Basket/Delete/5
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
