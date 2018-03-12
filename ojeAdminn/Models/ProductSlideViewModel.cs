using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oforadata.Data;
namespace ojeAdminn.Models
{
    public class ProductSlideViewModel
    {

        public int Id { get; set; }
       

        public List<category> pr { get; set; }


       
        public Nullable<int> cId { get; set; }
        public string Sliderimage { get; set; }
        public string Yazi { get; set; }

    }
}
