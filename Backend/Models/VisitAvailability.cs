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
        public IEnumerable<Doctor> Doctor { get; set; }         //dodac 's' na koncu
        public String Specialization { get; set; }
 
        public int DoctorsAvailable { get { if (this.Doctor == null) return 0; return this.Doctor.Count(); } }

        public bool VisitAvailable { get
            {
                if (this.Date >= DateTime.Now && this.DoctorsAvailable > 0) return true;
                return false;
            } }

        public string VisitAvailabilityColor { get {
                if(this.Date < DateTime.Now)
                        {
                    return "lightgray";
                }
                else if (this.DoctorsAvailable == 0)
                {
                    return "red";
                }
                else
                {
                    return "lightgreen";
                }
            } }
    }
}
