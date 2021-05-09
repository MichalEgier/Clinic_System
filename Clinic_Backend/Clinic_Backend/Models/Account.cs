using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic_Backend.Models
{
    //Tutaj ostatecznie bedzie jeden account! Tylko bedzie jeszcze atrybut Role !!!
    public class Account
    {
        public String Login { set; get; }
        public String Password { set; get; }
        public String Role { set; get; }
        //public String Email {set; get;}   //tego wstepnie nie bo nie wiem narazie jak by to w Identity mialo wygladac
    }
}
