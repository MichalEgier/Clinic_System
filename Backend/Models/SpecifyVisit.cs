using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class SpecifyVisit
    {
        public int ID { get; set; }
        [Required]
        [NotMapped]
        public String Specialization { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
