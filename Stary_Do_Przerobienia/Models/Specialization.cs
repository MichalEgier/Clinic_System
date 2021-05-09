using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string SpecializationName { set; get; }

    }
}
