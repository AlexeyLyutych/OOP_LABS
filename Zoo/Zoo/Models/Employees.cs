using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Employees
    {
        [Key]
        public int IDOfCertification {get;set;}
        public string Name { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public DateTime BDAY { get; set; }
        public string PhoneNumber { get; set; }

    }
}
