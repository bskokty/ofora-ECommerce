using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oforadata.Data;
namespace ojeAdminn.Models
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public string desciption { get; set; }
        public string smdesc { get; set; }
        public int stockStatus { get; set; }
        public int cId { get; set; }
        public product prod = new product();
        public List<category> categoryy = new List<category>();

        public image imge = new image();
    }
}