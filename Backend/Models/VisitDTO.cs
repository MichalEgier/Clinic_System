using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    [NotMapped]
    public class VisitDTO
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Date of visit")]
        public DateTime VisitDate { set; get; }
        public int DoctorID { set; get; }
        public int VisitCabinet { set; get; }
        [Required]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Pesel must be in 11 digits format!")]
        public string Pesel { set; get; }
        //not required!
        [Display(Name = "Brief previsit information")]
        public string PatientPrevisitNote { set; get; }
        //required even when patient calls for visit reservation
        [Required]
        [Display(Name = "Phone number")]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Phone number must be in 9 digits format!")]
        public string TelephoneNumber { get; set; }

        //yeah, i know that DTO is not supossed to have methods in it, but it's must be done quickly
        public string HtmlDateFormat { get
            {
                return $"{VisitDate.Year}-{VisitDate.Month.ToString("D2")}-{VisitDate.Day.ToString("D2")}T{VisitDate.Hour.ToString("D2")}:{VisitDate.Minute.ToString("D2")}";
            } }
    }
}
