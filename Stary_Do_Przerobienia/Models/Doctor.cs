using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
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
