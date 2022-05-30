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

        //public ObservableCollection<Patient> PatientsList { get; set; }  //NE MOZE ISTO KAO NA FRONTENDU



        public CreateAcc()
        {
            InitializeComponent();
            DataContext = this;
            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);    //inicijalizacija repozitorijuma
        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {         
                d = DP1.Text;
                //dt = DateTime.Parse(d);
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            _birthDate = d;
            _patientName = PatientName.Text;
            _patientSurname = PatientSurname.Text;
            _patientUsername = PatientUsername.Text;
            _patientAdress = PatientAdress.Text;
            _patientEmail = PatientEmail.Text;

            Patient patient = new Patient(_patientName, _patientSurname, _birthDate, _patientUsername, _patientAdress, _patientEmail);
            //MessageBoxResult result = MessageBox.Show(_patientName);
            Patient p = _patientRepository.AddPatient(patient);

            

            NewAccount.Content = new AllPatients();


        }
    }
}
