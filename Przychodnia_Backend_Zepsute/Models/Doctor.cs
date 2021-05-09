using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia_Backend.Models
{
    public class Doctor
    {
        public int DoctorID { set; get; }
        public Person PersonData { set; get; }
        public ICollection<Specialization> Specializations { set; get; }
        public String Title { set; get; }
    }
}
