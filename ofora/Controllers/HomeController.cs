using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oforadata.Data;
using ofora.Models;

namespace ofora.Controllers
{
    public class HomeController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Home

        public ActionResult Index(int? id)
        {

            if (user != null)
            {

                ViewBag.kullanici = "kullanici";
                ViewBag.sepet = datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).Count();

            }

            CategoryProductViewModel proc = new CategoryProductViewModel();
            if (id == null)
            {
                proc.img = datas.images.ToList();
                proc.pbr = datas.baskets.OrderByDescending(u=>u.id).Take(3).ToList();
                foreach (var item in proc.pbr)
                {
                    foreach (var item2 in datas.images.ToList())
                    {
                        if (item2.pid == item.pid)
                        {
                            proc.img2.Add(item2);
                        }

                    }
                }
                return View(proc);
            }
          
            proc.img = datas.images.Where(u=>u.product.category.Id==id).ToList();
            proc.pbr= datas.baskets.Take(5).ToList();
            foreach (var item in proc.pbr)
            {
                foreach (var item2 in datas.images.ToList())
                {
                    if (item2.pid==item.pid)
                    {
                        proc.img2.Add(item2);
                    }

                }
            }
            return View(proc);


        }
        public ActionResult Index2(string ad)
        {

            if (user != null)
            {

                ViewBag.kullanici = "kullanici";
                ViewBag.sepet = datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).Count();

            }
          
            CategoryProductViewModel proc = new CategoryProductViewModel();
            proc.img = datas.images.Where(u => u.product.marka == ad).ToList();
            proc.pbr = datas.baskets.Take(5).ToList();
            foreach (var item in proc.pbr)
            {
                foreach (var item2 in datas.images.ToList())
                {
                    if (item2.pid == item.pid)
                    {
                        proc.img2.Add(item2);
                    }

                }
            }
            return View(proc);


        }

        public ActionResult Odeme(int id)
        {
            ViewBag.basketid= datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).FirstOrDefault().basketId;
            return View();
        }
        public ActionResult remove(int id)
        {
            datas.baskets.Remove(datas.baskets.Where(y => y.pid == id && y.uid==user.Id).FirstOrDefault());
            datas.SaveChanges();
            return RedirectToAction("basket");
        }
        public ActionResult odemeyap(int id)
        {
            if (ModelState.IsValid)
            {
               List<basket> bsk= datas.baskets.Where(u => u.basketId == id && u.odeme==2).ToList();
                basket bask = datas.baskets.Where(u => u.basketId == id && u.odeme == 2).FirstOrDefault();
                foreach (var item in bsk)
                {
                    item.odeme = 1;
                }
                //product pro = datas.products.Where(x => x.Id == bask.pid).FirstOrDefault();
                //pro.stockStatus = pro.stockStatus - 1;
                datas.stockStatus.Remove(datas.stockStatus.Where(s => s.pId == bask.pid).FirstOrDefault());
               
                datas.SaveChanges();
                return RedirectToAction("basket");
            }
            return View();
        }
        public ActionResult basket()
        {
            if (user != null)
            {

                ViewBag.kullanici = "kullanici";
                ViewBag.sepet = datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).Count();
            }
            basketİmageViewModel bskt = new basketİmageViewModel();
            if (datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).FirstOrDefault()!=null)
            {
            bskt.bask = datas.baskets.Where(u=>u.uid==user.Id && u.odeme==2).ToList();
            foreach (var item in bskt.bask)
            {
               bskt.imag.Add(datas.images.Where(u => u.pid == item.pid).FirstOrDefault());
            }
            bskt.x = 0;
            foreach (var item in bskt.bask)
            {
                bskt.x = item.price + bskt.x;
         
            
            }
            bskt.basketid = datas.baskets.Where(u => u.uid == user.Id && u.odeme == 2).FirstOrDefault().basketId;
            return View(bskt);
            }

            ViewBag.mesaj = "Sepetiniz Boş.";

            return View();
        }
        public ActionResult Giris(FormCollection frm)
        {
            User us = new User();

            us.userName = frm["Email"];
            us.password = frm["Parola"].ToString();
            us.onayDurumu = 2;
            us.ustatus = 3;

            
            datas.Users.Add(us);
            datas.SaveChanges();
            return RedirectToAction("Index");
        }
        public PartialViewResult Guncelle(int id,int id2)
        {
            image img = datas.images.Where(a => a.id == id2).FirstOrDefault();

            if (id == 1)
            {
                ViewBag.param = img.folderName1;
            }
            if (id == 2)
            {
                ViewBag.param = img.folderName2;
            }
            if (id == 3)
            {
                ViewBag.param = img.folderName;
            }
            return PartialView();
        }
        // GET: Home/Details/5
        public ActionResult Detail(int id)
        {
            if (user != null)
            {

                ViewBag.kullanici = "kullanici";

            }
            image img = datas.images.Where(f=>f.id==id).FirstOrDefault();
            return View(img);
        }

        // GET: Home/Create
        public PartialViewResult FooterMenu()
        {//kampanya urunlerı lıstesı gonderılecek
            return PartialView();
        }

        // POST: Home/Create
     
        // GET: Home/Edit/5
        public PartialViewResult Slider()
        {//Slider verileri listesi gonderıcek

            List<Slider> sli =datas.Sliders.ToList();
            return PartialView(sli);
        }

       

        // GET: Home/Delete/5
        public PartialViewResult Category()
        {
            CategoryProductViewModel cat = new CategoryProductViewModel();
            cat.cr = datas.categories.ToList();
            //Soru !!Linq ile nasıl yaparım tekrarsız sutuna göre
           
            List<product> prs = datas.products.ToList();
            for (int i = 0; i < prs.Count; i++)
            {
                if (i==0)
                {
                    cat.pr.Add(prs[i]);
                   //int a=datas.products.Where(u => u.marka == prs[i].marka).GroupBy(u=>u.marka).Count();
                }
                else if (prs[i-1].marka!=prs[i].marka)
                {
                    cat.pr.Add(prs[i]);
                    //cat.adet.Add(datas.products.Where(u => u.Id == prs[i].Id).Count());
                }

            }
            
            return PartialView(cat);
        }

        public ActionResult login(int? id)
        {//Slider verileri listesi gonderıcek
            if (id!=null)
            {
                ViewBag.hata = "Kullanıcı adı veya şifre hatalı";
            }
            return View();
        }
        
        public ActionResult Spet(int id)
        {//Slider verileri listesi gonderıcek
            basket bskt = new basket();
            if (datas.baskets.Where(n => n.pid == id && n.uid == user.Id).FirstOrDefault() != null)
            {
                datas.baskets.Where(n => n.pid == id && n.uid == user.Id).FirstOrDefault().adet++;

            }
            else
            {
                bskt.pid = id;
                bskt.uid = user.Id;
                bskt.adet = 1;
                product pro = datas.products.Where(n => n.Id == id).FirstOrDefault();
                bskt.date = DateTime.Now;
                bskt.price = Convert.ToInt32(pro.price);
                bskt.onay = 2;
                bskt.odeme = 2;
                int a = datas.baskets.Max(n => n.basketId);
                int b = datas.baskets.Max(n => n.uid);
                if (b == user.Id)
                {
                    bskt.basketId = a;
                }
                else
                {
                    bskt.basketId = (a + 1);
                }

                datas.baskets.Add(bskt);
            }
            datas.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Sepet(FormCollection frm)
        {//Slider verileri listesi gonderıcek
            basket bskt = new basket();
            int x = Convert.ToInt32(frm["product.Id"]);
            if (datas.baskets.Where(n => n.pid == x && n.uid == user.Id).FirstOrDefault() != null)
            {
                datas.baskets.Where(n => n.pid == x && n.uid == user.Id).FirstOrDefault().adet++;

            }
            else
            {
                bskt.pid = Convert.ToInt32(frm["product.Id"]);
                bskt.uid = user.Id;
                bskt.adet = Convert.ToInt32(frm["adet"]);
                product pro = datas.products.Where(n => n.Id == bskt.pid).FirstOrDefault();
                bskt.date = DateTime.Now;
                bskt.price = Convert.ToInt32(pro.price * bskt.adet);
                bskt.onay = 2;
                bskt.odeme = 2;
                int a = datas.baskets.Max(n => n.basketId);
                int b = datas.baskets.Max(n => n.uid);
                if (b == user.Id)
                {
                    bskt.basketId = a;
                }
                else
                {
                    bskt.basketId = (a + 1);
                }

                datas.baskets.Add(bskt);
            }
            datas.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}