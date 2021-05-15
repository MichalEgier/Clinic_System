using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp1.Models
{

    public class Doctor
    {
        public Doctor()
        {

        }

        public Doctor(int id, string name, string surname, ICollection<Specialization> specializations, string title)
        {
            this.DoctorID = id;
            this.Name = name;
            this.Surname = surname;
            this.Specializations = specializations;
            this.Title = title;
        }

        //konstruktor

        public int DoctorID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]
        public string Surname { set; get; }
        [Required]
        [NotMapped]
        public ICollection<Specialization> Specializations { set; get; }
        [Required]
        public String Title { set; get; }

        //   public IFormFile Photo { set; get; }

        //Tutaj jeszcze zdjecie doktora

        public bool Equals(Doctor anotherDoctor)
        {
            return anotherDoctor.DoctorID == this.DoctorID;
        }

        [NotMapped]
        [Display(Name = "Doctor")]
        public string DoctorLabel { get { return this.Title + " " + this.Name + " " + this.Surname; } }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name = " + Name + " Surname = " + Surname + " Title " + Title + " Specializations = ");
            sb.Append(this.CommaSeparatedSpecializations);
            return sb.ToString();
        }

        public string CommaSeparatedSpecializations
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                if (Specializations.Count == 0)
                    sb.Append("None");
                else
                    foreach (var spec in Specializations)
                        sb.Append(spec.SpecializationName + ", ");
                return sb.ToString();
            }
        }

        /*
        [Required]
        [MaxLength(40, ErrorMessage ="Name too long, maximum length = {1}")]
        public String Name { set; get; }
        [Required]
        public Specialization Specialization { set; get; }
        [Required]
        public double Price { set; get; }
     [NotMapped]
        public IFormFile Image { set; get; }

        public string Filepath { set; get; }
        public string AbsoluteFilepath { set; get; }

        */

    }
}
