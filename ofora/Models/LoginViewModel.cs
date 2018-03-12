using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ofora.Models
{
    public class LoginViewModel
    {
            [Display(Name = "username")]
            [Required(ErrorMessage = "Bu alan boş geçilemez")]

            public string userName { get; set; }



            [Required(ErrorMessage = "Bu alan boş geçilemez")]
            [MinLength(6, ErrorMessage = "En az 6 haneli")]
            public string password { get; set; }
        
    }
}
