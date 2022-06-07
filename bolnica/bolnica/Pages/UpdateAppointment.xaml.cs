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
    /// Interaction logic for UpdateAppointment.xaml
    /// </summary>
    public partial class UpdateAppointment : Page
    {
        private DateTime _startAppointment;
        // private string _timeAppointment;
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
        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\appointments.txt";
        private const string CSV_DELIMITER = ";";

        public ObservableCollection<Patient> PatientsList { get; set; }  //NE MOZE ISTO KAO NA FRONTENDU
        public ObservableCollection<Doctor> DoctorsList { get; set; }
        public ObservableCollection<Room> RoomsList { get; set; }

        private Appointment tempAppointment;
        public UpdateAppointment(Appointment appointment)
        {
            InitializeComponent();
            DataContext = this;

            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);
            _doctorRepository = new DoctorRepository(DOCTOR_FILE, CSV_DELIMITER);
            _roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);
            _appointmentRepository = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER);

            PatientsList = new ObservableCollection<Patient>(_patientRepository.GetAll().ToList());
            DoctorsList = new ObservableCollection<Doctor>(_doctorRepository.GetAll().ToList());
            RoomsList = new ObservableCollection<Room>(_roomRepository.GetAll().ToList());

            Patients.ItemsSource = PatientsList;    //Patients - combobox sa frontenda
            Doctors.ItemsSource = DoctorsList;
            Rooms.ItemsSource = RoomsList;

            tempAppointment = appointment;
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
            //d = DP1.Text;
            _startAppointment = dt;

            //ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            //_timeAppointment = cboitem.Content.ToString();

            Patient cboPatient = Patients.SelectedItem as Patient;
            _patientName = cboPatient.Name;

            Doctor cboDoctor = Doctors.SelectedItem as Doctor;
            _doctorName = cboDoctor.Name;

            Room cboRoom = Rooms.SelectedItem as Room;
            _roomName = cboRoom.Name;

            //Appointment appointment = new Appointment(_startAppointment, _patientName, _doctorName, _roomName);
            tempAppointment.PatientName = _patientName;
            tempAppointment.DoctorName = _doctorName;
            tempAppointment.RoomName = _roomName;
            tempAppointment.Start = _startAppointment;
            Appointment a = _appointmentRepository.UpdateAppointment(tempAppointment);


            //public Appointments(Appointment appointment);

            //NewApp.Content = new Appointments();    //vodi na stranicu sa svim zakazanim pregledima
            var page = new Appointments();
            NavigationService.Navigate(page);
        }
    }
}
