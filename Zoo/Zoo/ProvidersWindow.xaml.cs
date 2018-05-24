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
using System.Resources;
using Zoo.Validation;
namespace Zoo
{
    /// <summary>
    /// Логика взаимодействия для ProvidersWindow.xaml
    /// </summary>
   
    public partial class ProvidersWindow : Window
    {
        

        ZooContex db;
        public ProvidersWindow()
        {
            
            InitializeComponent();
            db = new ZooContex();
            db.Providers.Load();
            db.Supplies.Load();
            ProvidersGrid.ItemsSource = db.Providers.Local.ToBindingList();
            SupplyGrid.ItemsSource = db.Supplies.Local.ToBindingList();
            DataContext = this;
            namebox.ItemsSource = db.Providers.Local.Select(n => n.СompanyName).ToList();
        }

        private void addSupplybtn_Click(object sender, RoutedEventArgs e)
        {
            Supply supply = new Supply();
            supply.Company = namebox.Text;
            supply.Amount = Convert.ToInt32(AmountTextBox.Text);
            supply.SupDate = Convert.ToDateTime(datepicker.Text + " " + HourTextBox.Text + ":" + MinuteTextBox.Text);
            db.Supplies.Add(supply);
            db.SaveChanges();
        }

        private void AddProviderbtn_Click(object sender, RoutedEventArgs e)
        {
           
                Provider provider = new Provider();
                provider.CheckingAccount = AccountTextBox.Text;
                provider.PhoneNumber = NumberTextBox.Text;
                provider.TypeOfProduct = TypeTextBox.Text;
                provider.СompanyName = CompanyTextBox.Text;
                db.Providers.Add(provider);
                db.SaveChanges();
           
          


        }

     

        private void Clearbtn_Click(object sender, RoutedEventArgs e)
        {
            searchtext.Clear();
            ProvidersGrid.ItemsSource = db.Providers.Local.ToBindingList();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            ProvidersGrid.ItemsSource = db.Providers.Local.Where(n => n.СompanyName.Contains(searchtext.Text) || 
            n.СompanyName.ToLower().Contains(searchtext.Text));
        }

        private void deleteButton1_Click(object sender, RoutedEventArgs e)
        {
            if (SupplyGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < SupplyGrid.SelectedItems.Count; i++)
                {
                    Models.Supply emp = SupplyGrid.SelectedItems[i] as Models.Supply;
                    if (emp != null)
                    {
                        db.Supplies.Remove(emp);
                    }
                }
            }
            db.SaveChanges();
        }

      

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProvidersGrid.SelectedItems.Count > 0)
            {
                for (int i = 0; i < ProvidersGrid.SelectedItems.Count; i++)
                {
                    Models.Provider emp = ProvidersGrid.SelectedItems[i] as Models.Provider;
                    if (emp != null)
                    {
                        db.Providers.Remove(emp);
                    }
                }
            }
            db.SaveChanges();
        }
    }
}
