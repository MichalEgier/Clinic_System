using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Models
{
    public class Cabinet
    {
        public Cabinet()
        {

        }
        public Cabinet(int id, string name)
        {
            this.CabinetID = id;
            this.CabinetName = name;
        }
        public int CabinetID { set; get; }
        [Required]
        public string CabinetName { set; get; } //to tez zmienic w bazie danych bo jest inaczej troche 
    }
}
