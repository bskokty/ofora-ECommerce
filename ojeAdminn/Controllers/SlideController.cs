using oforadata.Data;
using ojeAdminn.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ojeAdminn.Controllers
{
    public class SlideController : Controller
    {
        ojelerForaEntities1 datas = new ojelerForaEntities1();
        User user = Commonn.General.checkToken();
        // GET: Slide
        public ActionResult Index()
        {
            List<Slider> sli = datas.Sliders.ToList();
            return View(sli);
        }

        // GET: Slide/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Slide/Create
        public ActionResult Create()
        {
            List<category> pr = datas.categories.ToList();
            return View(pr);
        }

        // POST: Slide/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            Slider slg = new Slider();
           

            slg.cId = Convert.ToInt32(frm["basliksec"]);
            slg.Yazi = frm["Yazi"].ToString();



            if (Request.Files.Count > 0)
            {


                string path = Server.MapPath("/");



                if (Directory.Exists(path + "/slideImg") == false)
                {


                    Directory.CreateDirectory(path + "slideImg/");
                }

                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "slideImg/" + Request.Files["pic"].FileName);
                }

            }

            slg.Sliderimage = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "slideImg/" + Request.Files["pic"].FileName;


            datas.Sliders.Add(slg);
            datas.SaveChanges();
      
      
            return RedirectToAction("Index");
        }



        // GET: Slide/Edit/5
        public ActionResult Edit(int id)
        {
            ProductSlideViewModel proc = new ProductSlideViewModel();
            proc.Id = id;
            proc.pr = datas.categories.ToList();
            proc.cId = datas.Sliders.Where(a => a.Id == id).FirstOrDefault().cId;
            proc.Sliderimage = datas.Sliders.Where(a => a.Id == id).FirstOrDefault().Sliderimage;
            proc.Yazi = datas.Sliders.Where(a => a.Id == id).FirstOrDefault().Yazi;

            return View(proc);

        }
        // POST: Slide/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {
          
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            Slider slg = datas.Sliders.Where(a=>a.Id==id).FirstOrDefault();


            slg.cId = Convert.ToInt32(frm["basliksec"]);
            slg.Yazi = frm["Yazi"].ToString();


            

            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("/");
                
                if (Directory.Exists(path + "/slideImg") == false)
                {


                    Directory.CreateDirectory(path + "slideImg/");
                }

                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "slideImg/" + Request.Files["pic"].FileName);
                }
                
            }
            slg.Sliderimage = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "slideImg/" + Request.Files["pic"].FileName;
            datas.SaveChanges();
            return RedirectToAction("Index");


        
        }

        // GET: Slide/Delete/5
        public ActionResult Delete(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            datas.Sliders.Remove(datas.Sliders.Where(a => a.Id == id).FirstOrDefault());
          
            datas.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: Slide/Delete/5
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
