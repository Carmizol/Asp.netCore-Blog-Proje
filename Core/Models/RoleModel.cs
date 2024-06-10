using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class RoleModel
    {
        [Required(ErrorMessage = "Lütfen Bir Rol Adı Giriniz.")]
        public string name { get; set; }
    }
}
