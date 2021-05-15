using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class SpecializationDoctorBridge
    {
        [Key]
        public int SpecializationDoctorBridgeID { set; get; }
        [Required]
        public Doctor Doctor { set; get; }
        [Required]
        public Specialization Specialization { set; get; }
    }
}
