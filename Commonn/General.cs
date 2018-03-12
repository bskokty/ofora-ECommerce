using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Commonn
{

    public class General
    {
        public static User checkToken()
        {
            HttpCookie cok = HttpContext.Current.Request.Cookies["tk"];



            if (cok == null)
            {
                return null;

            }


            ojelerForaEntities1 datas = new ojelerForaEntities1();


            Token token = datas.Tokens.Where(t => t.tokentext == cok.Value && t.endate > DateTime.Now).FirstOrDefault();


            if (token == null)
            {

                HttpCookie ck = new HttpCookie("tk");
                ck.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(ck);
                return null;

            }

            return token.User;


        }


    }
}