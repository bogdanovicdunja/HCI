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
    /// Interaction logic for NewMeeting.xaml
    /// </summary>
    public partial class NewMeeting : Page
    {
        private DateTime _startMeeting;
        private string _roomName;
        private string _topic;

        public string t;
        public string d;
        DateTime dt;

        //private PatientRepository _patientRepository;
        //private DoctorRepository _doctorRepository;
        private RoomRepository _roomRepository;
        private MeetingRepository _meetingRepository;


        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string MEETING_FILE = _projectPath + "\\Resources\\meetings.txt";
        //private string DOCTOR_FILE = _projectPath + "\\Resources\\doctors.txt";
        private string ROOM_FILE = _projectPath + "\\Resources\\rooms.txt";
        //private string APPOINTMENT_FILE = _projectPath + "\\Resources\\appointments.txt";
        private const string CSV_DELIMITER = ";";

        public ObservableCollection<Room> RoomsList { get; set; }

        public NewMeeting()
        {
            InitializeComponent();
            DataContext = this;

            _roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);
            _meetingRepository = new MeetingRepository(MEETING_FILE, CSV_DELIMITER);

            RoomsList = new ObservableCollection<Room>(_roomRepository.GetAll().ToList());
            Rooms.ItemsSource = RoomsList;  //Rooms - combobox sa frontenda

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
            _startMeeting = dt;

            Room cboRoom = Rooms.SelectedItem as Room;
            _roomName = cboRoom.Name;

            _topic = Topics.Text;

            Meeting meeting = new Meeting(_startMeeting, _roomName, _topic);
            Meeting m = _meetingRepository.AddMeeting(meeting);


            NewMeet.Content = new Meetings();
        }

      
    }
}
