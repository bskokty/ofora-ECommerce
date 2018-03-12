using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oforadata.Data;
using System.Data.SqlClient;
using System.IO;
using ojeAdminn.Models;

namespace ojeAdminn.Controllers
{
    public class ProductsController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Products
        public ActionResult Index()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<product> prd = datas.products.ToList();
            return View(prd);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            ProductCategoryViewModel categ = new ProductCategoryViewModel();
            categ.categoryy = datas.categories.ToList();
            return View(categ);
        }
        //public ActionResult menu()
        //{
        //    List<category> ctg = datas.categories.ToList();
        //    return View(ctg);

        //}
        // POST: Products/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            product blg = new product();


            blg.name = frm["prod.name"].ToString();
            blg.price = Convert.ToDecimal(frm["prod.price"]);
            blg.desciption = frm["prod.desciption"].ToString();
            blg.smdesc = frm["prod.smdesc"].ToString();
            blg.cId = Convert.ToInt32(frm["basliksec"]);


            datas.products.Add(blg);

            datas.SaveChanges();

            if (Request.Files.Count > 0)
            {
                image img = new image();

                string path = Server.MapPath("/");



                if (Directory.Exists(path + "/productImg") == false)
                {


                    Directory.CreateDirectory(path + "productImg/");
                }
           
                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                     Request.Files["pic"].SaveAs(path + "productImg/" + Request.Files["pic"].FileName);
                }
                img.folderName = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "productImg/" + Request.Files["pic"].FileName;

                if (Request.Files["pic2"].FileName != null)
                {
                    if (!string.IsNullOrEmpty(Request.Files["pic2"].FileName))
                    {
                        Request.Files["pic2"].SaveAs(path + "productImg/" + Request.Files["pic2"].FileName);
                    }
                    img.folderName1= string.IsNullOrEmpty(Request.Files["pic2"].FileName) == true ? "" : "productImg/" + Request.Files["pic2"].FileName;
                }

                if (Request.Files["pic3"].FileName != null)
                {
                    if (!string.IsNullOrEmpty(Request.Files["pic3"].FileName))
                    {
                        Request.Files["pic3"].SaveAs(path + "productImg/" + Request.Files["pic3"].FileName);
                    }
                    img.folderName2 = string.IsNullOrEmpty(Request.Files["pic3"].FileName) == true ? "" : "productImg/" + Request.Files["pic3"].FileName;
                }
                img.pid = datas.products.Max(q => q.Id);
                datas.images.Add(img);

                stockStatu abc = new stockStatu();
                abc.pId = datas.products.Max(q => q.Id);
                datas.stockStatus.Add(abc);
                    datas.SaveChanges();
            }
            
                return RedirectToAction("Index");
           
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            ProductCategoryViewModel proc = new ProductCategoryViewModel();

            proc.categoryy = datas.categories.ToList();
            proc.prod=datas.products.Where(a => a.Id == id).FirstOrDefault();
            proc.cId = datas.products.Where(a => a.Id == id).FirstOrDefault().cId;
            proc.imge = datas.images.Where(a => a.pid == id).FirstOrDefault();
            ViewBag.categ = proc.cId;
            ViewBag.mesaj = "Güncelle";
            return View("create",proc);
        }

        // POST: Products/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            product blg = datas.products.Where(a=>a.Id==id).FirstOrDefault();


            blg.name = frm["prod.name"].ToString();
            blg.price = Convert.ToDecimal(frm["prod.price"]);
            blg.desciption = frm["prod.desciption"].ToString();
            blg.smdesc = frm["prod.smdesc"].ToString();
            blg.cId = Convert.ToInt32(frm["basliksec"]);
            int r = blg.Id;
            datas.SaveChanges();

            if (Request.Files.Count > 0)
            {
                image img = new image();

                if (datas.images.Where(d => d.id == r).FirstOrDefault() == null)
                {
                    img = new image();
                }
                else
                {
                    img = datas.images.Where(d => d.id == r).FirstOrDefault();
                }
                string path = Server.MapPath("/");



                if (Directory.Exists(path + "/productImg") == false)
                {


                    Directory.CreateDirectory(path + "productImg/");
                }

                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "productImg/" + Request.Files["pic"].FileName);
                    img.folderName = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "productImg/" + Request.Files["pic"].FileName;
                }
             
               
            if (Request.Files["pic2"].FileName != null)
                {
                    if (!string.IsNullOrEmpty(Request.Files["pic2"].FileName))
                    {
                        Request.Files["pic2"].SaveAs(path + "productImg/" + Request.Files["pic2"].FileName);
                        img.folderName1 = string.IsNullOrEmpty(Request.Files["pic2"].FileName) == true ? "" : "productImg/" + Request.Files["pic2"].FileName;
                    }
                   
                }

                if (Request.Files["pic3"].FileName != null)
                {
                    if (!string.IsNullOrEmpty(Request.Files["pic3"].FileName))
                    {
                        Request.Files["pic3"].SaveAs(path + "productImg/" + Request.Files["pic3"].FileName);
                        img.folderName2 = string.IsNullOrEmpty(Request.Files["pic3"].FileName) == true ? "" : "productImg/" + Request.Files["pic3"].FileName;
                    }
                 
                }
                img.pid = r;

                if (datas.images.Where(d => d.id == r).FirstOrDefault() == null)
                {
                    datas.images.Add(img);
                    datas.SaveChanges();
                }
                else
                {
                    datas.SaveChanges();
                }

               
            }

            return RedirectToAction("Index");

            
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            datas.images.Remove(datas.images.Where(a => a.pid == id).FirstOrDefault());
            datas.stockStatus.Remove(datas.stockStatus.Where(s => s.pId == id).FirstOrDefault());
            datas.products.Remove(datas.products.Where(a => a.Id == id).FirstOrDefault());
            datas.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Products/Delete/5
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
