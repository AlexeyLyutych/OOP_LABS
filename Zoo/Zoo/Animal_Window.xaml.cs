using System;
using System.Collections.Generic;
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
using System.Data.Entity;
using Microsoft.Win32;
using Zoo.Validation;

namespace Zoo
{
    
    /// <summary>
    /// Логика взаимодействия для Animal_Window.xaml
    /// </summary>
    public partial class Animal_Window : Window
    {
        Animal an = new Animal();
        ZooContex db;
        public Animal_Window()
        {
            an = new Animal();
            DataContext = this;
            InitializeComponent();
            db = new ZooContex();
            db.Animals.Load();
            AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
         


        }
        private void phonesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Animal p = (Animal)AnimalList.SelectedItem;
            if (p != null)
            {
                KindText.Text = p.KindOfAnimal;
                NumberText.Text = Convert.ToString(p.Number);
                AviaryText.Text = Convert.ToString(p.AviaryNum);
                KeeperText.Text = Convert.ToString(p.KeeperID);
                select_img.Source = new BitmapImage(new Uri(p.ImagePath, UriKind.Absolute)); ;
            }
           
        }

        private void img_openbtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog open_dialog = new OpenFileDialog(); 
            open_dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; 
            if (open_dialog.ShowDialog() == true) 
            {
                try
                {
                    select_img.Source = new BitmapImage(new Uri(open_dialog.FileName, UriKind.Absolute)); ;
                }
                catch
                {
                  
                    MessageBox.Show("Невозможно открыть выбранный файл");
                    
                }
            }
        }

        private void delete_btn_Click(object sender, RoutedEventArgs e)
        {

            
            
            IEnumerable<Animal> an = db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text);
            if (an.Count() == 0)
            {
                MessageBox.Show("Животного такого вида не существует");
            }
            else
            {
                Animal animal = an.First();
                db.Animals.Remove(animal);
                db.SaveChanges();
                KeeperText.Clear();
                AviaryText.Clear();
                NumberText.Clear();
                KindText.Clear();
                select_img.Source = null;
            }
        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            Animal animal = new Animal();
            animal.ImagePath = Convert.ToString(select_img.Source);
            animal.KindOfAnimal = KindText.Text;
            animal.KeeperID = Convert.ToInt32(KeeperText.Text);
            animal.AviaryNum = Convert.ToInt32(AviaryText.Text);
            animal.Number = Convert.ToInt32(NumberText.Text);

            IEnumerable<Animal> an = db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text);
            foreach(Animal elem in an)
            {
                flag = true;
            }
            if (flag)
            {
                Animal anim= db.Animals.Local.Where(n => n.KindOfAnimal == KindText.Text).First();
                anim.KeeperID= Convert.ToInt32(KeeperText.Text);
                anim.AviaryNum= Convert.ToInt32(AviaryText.Text);
                anim.Number= Convert.ToInt32(NumberText.Text);
               
                  db.SaveChanges();
                
                MessageBox.Show("Изменено!");
               
               AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
                AnimalList.Items.Refresh();
            }
            else
            {
                db.Animals.Add(animal);
                db.SaveChanges();
                AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
                MessageBox.Show("Добавлено!");
            }


        }

        private void Query_Click(object sender, RoutedEventArgs e)
        {
            Output output = new Output();

            output.Show();
        }

        private void Searchbtn_Click(object sender, RoutedEventArgs e)
        {
            AnimalList.ItemsSource = db.Animals.Local.Where(n => n.KindOfAnimal.Contains(searchtext.Text) || n.KindOfAnimal.ToLower().Contains(searchtext.Text));
        }

        private void clearbtn_Click(object sender, RoutedEventArgs e)
        {
            searchtext.Clear();
            AnimalList.ItemsSource = db.Animals.Local.ToBindingList();
        }
    }
}
