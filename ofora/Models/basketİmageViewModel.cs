using oforadata.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ofora.Models
{
    public class basketİmageViewModel
    {
        public List<basket> bask = new List<basket>();
        public List<image> imag = new List<image>();

        public List<decimal> total = new List<decimal>();

        public decimal x   { get; set; }
        public int basketid { get; set; }

    }
}