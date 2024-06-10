using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Kullanıcı Adı Giriniz")]
        public string username { get; set; }

        [Required(ErrorMessage = "Parola Giriniz")]
        public string password { get; set; }
    }
}
