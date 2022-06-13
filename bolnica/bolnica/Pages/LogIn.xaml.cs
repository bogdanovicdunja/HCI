using bolnica.Model;
using bolnica.Repository;
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

        private SecretaryRepository _secretaryRepository;

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string SECRETARY_FILE = _projectPath + "\\Resources\\secretar.txt";
        private const string CSV_DELIMITER = ";";


        public LogIn()
        {
            InitializeComponent();
            var app = Application.Current as App;
            DataContext = this;

            _secretaryRepository = new SecretaryRepository(SECRETARY_FILE, CSV_DELIMITER);    //inicijalizacija repozitorijuma
        }

        private void Confirm_Click(object sender, RoutedEventArgs e)
        {


            _username = User.Text;

            if (_username == "")
            {
                MessageBoxResult result = MessageBox.Show("Username can't be empty!");
                return;
            }

            if (_secretaryRepository.FindSecretaryByUsername(_username) == null)
            {

                MessageBoxResult result = MessageBox.Show("Username is incorrect!");
                return;
            }


            _password = Pass.Password;

            if (_password == "")
            {
                MessageBoxResult result = MessageBox.Show("Password can't be empty!");
                return;
            }

            if (_secretaryRepository.FindSecretaryByUsername(_username) != null)
            {
                Secretary sec = _secretaryRepository.FindSecretaryByUsername(_username);
                if(sec.Password != _password)
                {
                    MessageBoxResult result;
                    result = MessageBox.Show("Password incorrect!");
                }
                else
                {
                    MessageBoxResult result;
                    result = MessageBox.Show("Password is correct!");

                    Window window = new SecretaryHomepage();
                    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    window.Show();
                    this.Close();
                }
            }
              
                
                //else
                //{
                //    MessageBoxResult result;

                //    result = MessageBox.Show("DOBRA SIFRA");
                //    Window window = new SecretaryHomepage();
                //    window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                //    //window.Height = 700;
                //    window.Show();
                //    this.Close();
                //}
           


            //Window window = new SecretaryHomepage();
            //window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
            //window.Show();
            //this.Close();
        }
    }
}
