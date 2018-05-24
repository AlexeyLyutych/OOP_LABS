using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Models
{
    public class Supply
    {
        [Key]
        public int ID_Sup { get; set; }
        public string Company { get; set; }
        public DateTime SupDate { get; set; }
        public int Amount { get; set; }
    }
}
