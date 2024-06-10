using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        public String UserName { get; set; }
        public String PassWord { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String ImageUrl { get; set; }
        public String Role { get; set; }
    }
}
