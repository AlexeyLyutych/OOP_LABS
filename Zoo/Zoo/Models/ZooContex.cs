using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Zoo.Models
{
    public class ZooContex:DbContext
    {
        public ZooContex() : base("DefaultConnection") { }
        public DbSet<Employees> Employess { get; set; }
        public DbSet<Animal> Animals{ get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Supply> Supplies { get; set; }
    }
}
