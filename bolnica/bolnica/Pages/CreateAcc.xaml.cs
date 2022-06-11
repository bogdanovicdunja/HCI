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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace bolnica.Pages
{
    /// <summary>
    /// Interaction logic for CreateAcc.xaml
    /// </summary>
    public partial class CreateAcc : Page
    {

        //private DateTime _birthDate;
        // private string _timeAppointment;
        private string _birthDate;
        private string _patientName;
        private string _patientSurname;
        private string _patientUsername;
        private string _patientAdress;
        private string _patientEmail;

        private string d;
        DateTime dt;

        private PatientRepository _patientRepository;
        
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string PATIENT_FILE = _projectPath + "\\Resources\\patients.txt";
        private const string CSV_DELIMITER = ";";




        public CreateAcc()
        {
            InitializeComponent();
            DataContext = this;
            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);    //inicijalizacija repozitorijuma
        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            //d = DP1.Text;
            //dt = DateTime.Parse(d);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _birthDate = DP1.Text;
            if (_birthDate == "")
            {
                MessageBoxResult result = MessageBox.Show("DOB can't be empty!");
                return;
            }

            _patientName = PatientName.Text;
            if (_patientName == "")
            {
                MessageBoxResult result = MessageBox.Show("Name can't be empty!");
                return;
            }

            _patientSurname = PatientSurname.Text;
            if (_patientSurname == "")
            {
                MessageBoxResult result = MessageBox.Show("Surname can't be empty!");
                return;
            }

            _patientUsername = PatientUsername.Text;
            if (_patientUsername == "")
            {
                MessageBoxResult result = MessageBox.Show("Username can't be empty!");
                return;
            }
            if (_patientRepository.FindPatientByUsername(_patientUsername) != null)
            {
            
                MessageBoxResult result = MessageBox.Show("Username " + _patientUsername + " already exists!");
            }

            _patientAdress = PatientAdress.Text;
            if (_patientAdress == "")
            {
                MessageBoxResult result = MessageBox.Show("Address can't be empty!");
                return;
            }

            _patientEmail = PatientEmail.Text;
            if (_patientEmail == "")
            {
                MessageBoxResult result = MessageBox.Show("Email can't be empty!");
                return;
            }


            Patient patient = new Patient(_patientName, _patientSurname, _birthDate, _patientUsername, _patientAdress, _patientEmail);
            Patient p = _patientRepository.AddPatient(patient);


            var page = new AllPatients();
            NavigationService.Navigate(page);


        }
    }
}
