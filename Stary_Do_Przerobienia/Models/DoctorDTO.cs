using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class DoctorDTO      //Class for creating new doctor (and editing currently existing one)
    {
        [Required]
        public String Name { set; get; }
        [Required]
        public String Surname { set; get; }
        [Required]
        [Display(Name = "Specializations")]
        [RegularExpression(@"\s*([A-Z][a-z]+\s)*([A-Z][a-z]+)*\s*", ErrorMessage = "Specify specializations by separating them with spaces, specialization should start with capital letter!")]
        public String SpecializationsString { set; get; }
        [Required]
        public String Title { set; get; }
          
    }
}
