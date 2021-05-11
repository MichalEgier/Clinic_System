using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Patient
    {
        public Patient()
        {

        }
        public Patient(int id, string name, string surname, string pesel)
        {
            this.PatientID = id;
            this.Name = name;
            this.Surname = surname;
            this.Pesel = pesel;
        }

        public int PatientID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Surname { set; get; }
        [Required]
        [RegularExpression(@"[0-9]{11}", ErrorMessage = "Pesel must be in 11 digits format!")]
        public string Pesel { set; get; }

    }
}
