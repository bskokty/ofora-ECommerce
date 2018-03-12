using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ojeAdminn.Models
{
    public class BasketViewModel
    {

      
        public string ad { get; set; }
        public decimal fiyat { get; set; }
        public int idd { get; set; }

        public List<basket> baskk = new List<basket>();
        //public int id { get; set; }
        //public int pid { get; set; }
        //public int uid { get; set; }
        //public System.DateTime date { get; set; }
        //public int piece { get; set; }
        //public int basketId { get; set; }
        //public Nullable<int> onay { get; set; }
    }
}