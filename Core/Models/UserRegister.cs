using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserRegister
    {
        [Display(Name ="Ad Soyad")]
        [Required(ErrorMessage = "Ad Soyad Giriniz.")]
        public string nameSurname { get; set; }

        [Display(Name = "Parola")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Parola Giriniz.")]
        public string Password { get; set; }

        [Display(Name ="Parola")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Parola Uyuşmuyor!")]
        public string ConfirmPassword { get; set; }

        [Display(Name ="Mail")]
        [Required(ErrorMessage ="Mail Giriniz.")]
        public string Mail { get; set; }

        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz.")]
        public string UserName { get; set; }


    }
}
