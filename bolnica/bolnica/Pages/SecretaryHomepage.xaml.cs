using bolnica.Model;
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

namespace bolnica.Pages
{
    /// <summary>
    /// Interaction logic for SecretaryHomepage.xaml
    /// </summary>
    public partial class SecretaryHomepage : Window
    {
        public SecretaryHomepage()
        {
            InitializeComponent();
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new CreateAcc();
           // this.Close();
            
        }

       
        private void Out_Click(object sender, RoutedEventArgs e)
        {
            //new LogIn()
            //{
            //    Owner = Application.Current.MainWindow
             
            //}.ShowDialog();
            //this.Close();

            Window window = new LogIn();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();
            this.Close();
            
            
        }

        private void Emergency_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new Emergency();
        }

        private void Files_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new AllPatients();
        }

        private void Meetings_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new Meetings();
        }

        private void Appointments_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content= new Appointments();
        }

        private void Surgeries_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new Surgery();
        }

        private void Equipment_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new Equipment();
        }

        private void DayOff_Click(object sender, RoutedEventArgs e)
        {
            Homepage.Content = new DayOff();
        }
    }
}
