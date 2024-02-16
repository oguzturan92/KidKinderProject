using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KidKinder.Models
{
    public class SendMessageViewModel
    {
        [Required(ErrorMessage = "Lütfen ad bilgisii boş geçmeyin")]
        [StringLength(30,ErrorMessage = "Lütfen en fazla 30 karakter veri girişi yapınız")]
        public string NameSurname { get; set; }

        [Required(ErrorMessage = "Lütfen email bilgisini boş geçmeyin")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri girişi yapınız")]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen konu bilgisini boş geçmeyin")]
        [StringLength(50, ErrorMessage = "Lütfen en fazla 50 karakter veri girişi yapınız")]
        [MinLength(5,ErrorMessage = "Lütfen en az 5 karakter veri girişi yapınız")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen mesaj bilgisini boş geçmeyin")]
        [StringLength(1000, ErrorMessage = "Lütfen daha az karakter veri girişi yapınız")]
        public string Message { get; set; }
    }
}