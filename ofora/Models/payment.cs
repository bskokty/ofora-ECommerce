using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ofora.Models
{
    public class payment
    {
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(12, ErrorMessage = "Şifreniz en az 12 haneli olmalıdır")]
        [Range(100000000000, 999999999999, ErrorMessage = "Eksik yada hatalı giriş yaptınız.")]
        public string card { get; set; }


        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [MinLength(3, ErrorMessage = "En az 3 haneli olmalıdır")]
        public string ccv { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        public string tarih { get; set; }


    }
}