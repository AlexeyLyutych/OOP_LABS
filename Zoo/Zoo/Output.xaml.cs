using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zoo.Models;
namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для Output.xaml
    /// </summary>
    public partial class Output : Window
    {
        public Output()
        {
            InitializeComponent();
            ZooContex db = new ZooContex();
            db.Animals.Load();
            db.Employess.Load();
            var select = from s in db.Employess
                         join sl in db.Animals
                         on s.IDOfCertification equals sl.KeeperID
                         select new { EmpName = s.Name, KindOfAnimal = sl.KindOfAnimal };
            foreach(var a in select)
            {
                NameInfo.Content += "\n"+a.EmpName ;
                KindInfo.Content += "\n"+a.KindOfAnimal ;
            }

           
        }
    }
}
