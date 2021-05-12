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
        //not required! only when patient calls for visit reservation
        [Phone]
        public string TelephoneNumber { set; get; }
    }
}
