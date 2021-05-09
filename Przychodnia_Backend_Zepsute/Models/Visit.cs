using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia_Backend.Models
{
    public class Visit
    {
        public DateTime VisitDate { set; get; }
        public Doctor Doctor { set; get; }
        public Patient Patient { set; get; }
        public Cabinet VisitCabinet { set; get; }

        public String PatientPrevisitNote { set; get; }
        public String VisitResultDescription { set; get; }
        /*
         * Tutaj jakies metody visit
         * */
    }
}
