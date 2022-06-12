using bolnica.Model;
using bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace bolnica.Pages
{
    /// <summary>
    /// Interaction logic for Guesst.xaml
    /// </summary>
    public partial class Guesst : Page
    {
        private PatientRepository _patientRepository;
   

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string PATIENT_FILE = _projectPath + "\\Resources\\patients.txt";
        private const string CSV_DELIMITER = ";";
        public Guesst()
        {
            InitializeComponent();
            DataContext = this;
            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {

            DateTime dt = DateTime.Now;                     
            string date_of_birth = dt.ToString("dd-MM-yyyy");
            string Username = User.Text;
            string Name = "N";
            string Surname = "N";
            string Adress = "Xxxx";
            string Email = "someone@gmail.com";

            if (_patientRepository.FindPatientByUsername(Username) == null)
            {
                 Patient p = new Patient(Name, Surname, date_of_birth, Username, Adress, Email);
                _patientRepository.AddPatient(p);

                var page = new Emergency();
                NavigationService.Navigate(page);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Username " + Username + " already exists!");
            }

            //var page = new Emergency();
            //NavigationService.Navigate(page);

        }

        
    }
}
