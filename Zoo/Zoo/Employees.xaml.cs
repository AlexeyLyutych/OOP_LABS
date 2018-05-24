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
    /// Логика взаимодействия для Employees.xaml
    /// </summary>
    public partial class Employees : Window
    {
        MainWindow main1 = new MainWindow();
        ZooContex db;
        public Employees()
        {
            InitializeComponent();

        }
        public Employees(MainWindow main)
        {
            InitializeComponent();
            main1 = main;
            db = new ZooContex();
            db.Employess.Load();
            EmployeesGrid.ItemsSource = db.Employess.Local.ToBindingList();
           this.Closing += Employees_Closing;
            
             
        }

        private void Employees_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
           db.Dispose();
            
        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {
            main1.Show();
            this.Close();
           
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < EmployeesGrid.SelectedItems.Count; i++)
                {
                    Models.Employees emp = EmployeesGrid.SelectedItems[i] as Models.Employees;
                    if (emp != null)
                    {
                        db.Employess.Remove(emp);
                    }
                }
            }
            db.SaveChanges();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            Search(searchtext.Text);
        }
        private void Search(string str1)
        {
                
         EmployeesGrid.ItemsSource = db.Employess.Local.Where(n => n.Name.Contains(str1)||n.Name.ToLower().Contains(str1));

        }

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            searchtext.Clear();
            EmployeesGrid.ItemsSource = db.Employess.Local.ToBindingList();
            
        }
        
    }
}
