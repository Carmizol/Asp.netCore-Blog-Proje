using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RaytingShare
    {
        [Key]
        public int RaytingId { get; set; }
        public int BlogId { get; set; }
        public int TotalScore { get; set; }
        public int RaytingCount { get; set; }
    }
}
