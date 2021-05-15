using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Specialization
    {
        public Specialization()
        {

        }
        public Specialization(int id, string name)
        {
            this.SpecializationName = name;
            this.SpecializationID = id;
        }
        public int SpecializationID { set; get; }
        [Required]
        [Display(Name = "Specialization name")]
        public string SpecializationName { set; get; }
        [NotMapped]
        public ICollection<Doctor> DoctorsWithSpecialization { set; get; } 

    }
}
