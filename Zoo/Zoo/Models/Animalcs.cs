using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zoo.Models
{
    public class Animal
    {
       [Key]
       public int ID { get; set; }
       public string KindOfAnimal { get; set; }
        public int Number { get; set; }
        public int AviaryNum { get; set; }
        public int KeeperID { get; set; }
        public string ImagePath { get; set; }

    }
}
