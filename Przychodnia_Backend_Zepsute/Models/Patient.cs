using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Przychodnia_Backend.Models
{
    public class Patient
    {
        public String Name { set; get; }
        public String Surname { set; get; }
        public String TelephoneNumber { set; get; }     //To dodac do tabelki bo nie ma jeszcze
                                                    //
        public Account PatientAccount {set; get;}
    }
}
