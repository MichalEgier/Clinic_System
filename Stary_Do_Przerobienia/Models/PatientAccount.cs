using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class PatientAccount : IdentityUser
    {

        //login i password juz beda w tym IdentityUser

        [PersonalData]
        public int AccountOwnerID { set; get; }     //it is foreign key to the patient, but unfortunatelly patient must be in another db
                                                                //so it must be manually handled in project, not inside database
//        public ICollection<Visit> AllVisits { set; get; }

        [Required]
        [RegularExpression(@"[0-9]{9}", ErrorMessage = "Telephone number must be in 9 digits format!")]
        [PersonalData]
        public string TelephoneNumber { set; get; }
    }
}
