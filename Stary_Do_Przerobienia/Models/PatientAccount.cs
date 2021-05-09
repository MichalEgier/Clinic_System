using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class PatientAccount
    {

        //login i password juz beda w tym IdentityUser

        public Patient AccountOwner { set; get; }

        [Required]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Telephone number must be in 9 digits format!")]
        public string TelephoneNumber { set; get; }
    }
}
