using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Zoo.Models
{
   public class Provider
    {

        [Key]
        public string СompanyName { get; set; }
        public string TypeOfProduct { get; set; }
       
        public string CheckingAccount { get; set; }
        public string PhoneNumber { get; set; }
    }
}
