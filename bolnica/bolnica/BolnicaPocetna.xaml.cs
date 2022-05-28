using bolnica.Pages;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace bolnica
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BolnicaPocetna : Window
    {
        public BolnicaPocetna()
        {
            InitializeComponent();
            DataContext = this;
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    new LogIn()
        //    {

        //        Owner = Application.Current.MainWindow

        //    }.ShowDialog();




        //    //this.Visibility = Visibility.Hidden;
        //}
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window window = new LogIn();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Show();

            this.Close();




            //this.Visibility = Visibility.Hidden;
        }


    }
}
