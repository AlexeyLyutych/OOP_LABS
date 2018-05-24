using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Zoo.Models;

namespace Zoo
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
            InitializeComponent();
            
            
            this.Closing += MainWindow_Closing;
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Notification();
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Associate_btn_Click(object sender, RoutedEventArgs e)
        {
            Employees employees = new Employees(this);

            employees.Show();
            
            
            



        }

        private void Animals_btn_Click(object sender, RoutedEventArgs e)
        {
            Animal_Window animal = new Animal_Window();
            animal.Show();
        }

        private void providers_btn_Click(object sender, RoutedEventArgs e)
        {
            ProvidersWindow providers = new ProvidersWindow();
            providers.Show();
        }
        private  void  Notification()
        {
            ZooContex db = new ZooContex();
            db.Supplies.Load();
            DateTime s = DateTime.Now;
             foreach(var elem in db.Supplies)
            {
                if (elem.SupDate.Day == s.Day && elem.SupDate.Month == s.Month)
                {
                    MessageBox.Show("Напоминание, у вас сегодня поставка!");
                }
            }
        }
    }
}
