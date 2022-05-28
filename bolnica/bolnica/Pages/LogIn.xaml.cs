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


namespace bolnica.Pages
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        public LogIn()
        {
            InitializeComponent();
            var app = Application.Current as App;
            DataContext = this;

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
      
            Window window = new SecretaryHomepage();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //window.Height = 700;
            window.Show();
            this.Close();
        }
    }
}
