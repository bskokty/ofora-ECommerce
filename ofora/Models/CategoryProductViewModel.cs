using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oforadata.Data;

namespace ofora.Models
{
    public class CategoryProductViewModel
    {
        
        public string name { get; set; }
        public decimal price { get; set; }
        public string desciption { get; set; }
        public string smdesc { get; set; }
        public int stockStatus { get; set; }
        public int cId { get; set; }
        public int Id { get; set; }
        public List<category> cr = new List<category>();
        public List<product> pr = new List<product>();
        public List<image> img = new List<image>();
        public List<image> img2 = new List<image>();
        public List<basket> pbr = new List<basket>();
        public List<int> adet = new List<int>();
    }
}