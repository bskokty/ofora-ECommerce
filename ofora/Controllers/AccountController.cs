using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oforadata.Data;
using Commonn;

namespace ofora.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ofora.Models.LoginViewModel userdata)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("login", "Home");



            ojelerForaEntities1 datas = new ojelerForaEntities1();

            User loginUser = datas.Users.Where(t => t.userName == userdata.userName && t.password == userdata.password && t.ustatus == 3 && t.onayDurumu==1).FirstOrDefault();




            if (loginUser == null)
            {
               
                return RedirectToAction("login","Home", new { id = 99 });

            }


            Token token = new Token();


            do
            {
                token.endate = DateTime.Now.AddHours(2);
                token.tokentext = RandomSfr.Generate(10);

            } while (datas.Tokens.Count(t => t.tokentext == token.tokentext) > 0);


            token.userId = loginUser.Id;

            datas.Tokens.Add(token);
            datas.SaveChanges();


            HttpCookie cok = new HttpCookie("tk");
            cok.Value = token.tokentext;
            cok.Expires = DateTime.Now.AddHours(2);


            Response.Cookies.Add(cok);

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            HttpCookie cok = HttpContext.Request.Cookies["tk"];
            ojelerForaEntities1 datas = new ojelerForaEntities1();
            Token token = datas.Tokens.Where(t => t.tokentext == cok.Value && t.endate > DateTime.Now).FirstOrDefault();
            token.endate = DateTime.Now.AddHours(-2);
            datas.SaveChanges();
           
            return RedirectToAction("Index", "Home");
        }
    }
}

