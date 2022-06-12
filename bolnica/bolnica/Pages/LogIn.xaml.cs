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
        private string _username;
        private string _password;
        public LogIn()
        {
            InitializeComponent();
            var app = Application.Current as App;
            DataContext = this;

        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {
            _username = User.Text;
            if (_username == "")
            {
                MessageBoxResult result = MessageBox.Show("Username can't be empty!");
                return;
            }


            _password = Pass.Text;
            if (_password == "")
            {
                MessageBoxResult result = MessageBox.Show("Password can't be empty!");
                return;
            }

            Window window = new SecretaryHomepage();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            //window.Height = 700;
            window.Show();
            this.Close();
        }
    }
}
