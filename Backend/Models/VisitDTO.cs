using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class VisitDTO
    {
        public int Id { get; set; }
        [Required]
        public DateTime VisitDate { set; get; }
        public int DoctorID { set; get; }
        public int VisitCabinet { set; get; }
        [Required]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Pesel must be in 11 digits format!")]
        public string Pesel { set; get; }
        //not required!
        public string PatientPrevisitNote { set; get; }
        //required even when patient calls for visit reservation
        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Phone number must be in 9 digits format!")]
        public string TelephoneNumber { get; set; }
    }
}
