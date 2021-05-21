using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class VisitAvailability
    {
        
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Doctor> Doctor { get; set; }
        public String Specialization { get; set; }
    }
}
