using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Visit
    {
        public Visit()
        {

        }
        public Visit(int id, DateTime visitDate, Doctor doctor, Patient patient, Cabinet visitCabinet, string patientPrevisitNote = "",
            string visitResultDescription = "", string? telephoneNumber = null)
        {
            this.VisitID = id;
            this.VisitDate = visitDate;
            this.Doctor = doctor;
            this.Patient = patient;
            this.VisitCabinet = visitCabinet;
            this.PatientPrevisitNote = patientPrevisitNote;
            this.TelephoneNumber = telephoneNumber;
        }
        public int VisitID { set; get; }
        [Required]
        public DateTime VisitDate { set; get; }
        //Not required!!
        public Doctor Doctor { set; get; }
        [Required]
        public Patient Patient { set; get; }
        //not required!
        public Cabinet VisitCabinet { set; get; }
        //not required!
        public string PatientPrevisitNote { set; get; }
        [Phone]
        public string TelephoneNumber { set; get; }
        /*
         * Tutaj jakies metody visit
         * */


    }
}
