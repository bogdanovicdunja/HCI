using bolnica.Model;
using bolnica.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for NewSuergery.xaml
    /// </summary>
    public partial class NewSurgery : Page
    {

        private DateTime _startAppointment;
        private string _patientName;
        private string _doctorName;
        private string _roomName;

        public string t;
        public string d;
        DateTime dt;

        private PatientRepository _patientRepository;
        private DoctorRepository _doctorRepository;
        private RoomRepository _roomRepository;
        private AppointmentRepository _appointmentRepository;

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string PATIENT_FILE = _projectPath + "\\Resources\\patients.txt";
        private string DOCTOR_FILE = _projectPath + "\\Resources\\doctors.txt";
        private string ROOM_FILE = _projectPath + "\\Resources\\rooms.txt";
        private string SURGERY_FILE = _projectPath + "\\Resources\\surgery.txt";
        private const string CSV_DELIMITER = ";";

        public ObservableCollection<Patient> PatientsList { get; set; }  //NE MOZE ISTO KAO NA FRONTENDU
        public ObservableCollection<Doctor> DoctorsList { get; set; }
        public ObservableCollection<Room> RoomsList { get; set; }

        public NewSurgery()
        {
            InitializeComponent();
            DataContext = this;

            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);
            _doctorRepository = new DoctorRepository(DOCTOR_FILE, CSV_DELIMITER);
            _roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);
            _appointmentRepository = new AppointmentRepository(SURGERY_FILE, CSV_DELIMITER);

            PatientsList = new ObservableCollection<Patient>(_patientRepository.GetAll().ToList());
            DoctorsList = new ObservableCollection<Doctor>(_doctorRepository.GetAll().ToList());
            RoomsList = new ObservableCollection<Room>(_roomRepository.GetAll().ToList());

            Patients.ItemsSource = PatientsList;    //Patients - combobox sa frontenda
            Doctors.ItemsSource = DoctorsList;
            Rooms.ItemsSource = RoomsList;
        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            if (cboitem.Content != null)
            {
                t = cboitem.Content.ToString();
                d = DP1.Text;

                dt = DateTime.Parse(d + " " + t);
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _startAppointment = dt;

            Patient cboPatient = Patients.SelectedItem as Patient;
            _patientName = cboPatient.Name;

            Doctor cboDoctor = Doctors.SelectedItem as Doctor;
            _doctorName = cboDoctor.Name;

            Room cboRoom = Rooms.SelectedItem as Room;
            _roomName = cboRoom.Name;

            Appointment appointment = new Appointment(_startAppointment, _patientName, _doctorName, _roomName);
            Appointment a = _appointmentRepository.AddAppointment(appointment);

            //NewSur.Content = new Surgery();
            var page = new Surgery();
            NavigationService.Navigate(page);
        }
    }
}
