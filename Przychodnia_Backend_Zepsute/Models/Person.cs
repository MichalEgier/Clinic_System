using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia_Backend.Models
{
    public class Person
    {
        public int PersonID { set; get; }
        public String Name { set; get; }
        public String Surname { set; get; }
        public String Pesel { set; get; }
    }
}
