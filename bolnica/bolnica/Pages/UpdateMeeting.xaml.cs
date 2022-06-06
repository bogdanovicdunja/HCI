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
    /// Interaction logic for UpdateMeeting.xaml
    /// </summary>
    public partial class UpdateMeeting : Page
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

        public Meeting tempMeeting;


        public UpdateMeeting(Meeting meeting)
        {
            InitializeComponent();
            DataContext = this;

            _roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);
            _meetingRepository = new MeetingRepository(MEETING_FILE, CSV_DELIMITER);

            RoomsList = new ObservableCollection<Room>(_roomRepository.GetAll().ToList());
            Rooms.ItemsSource = RoomsList;  //Rooms - combobox sa frontenda

            tempMeeting = meeting;




            this._topic = meeting.Topic;
            //this._roomName = meeting.RoomName;

        }

        //public String roomname
        //{
        //    get => _roomName;
        //    set
        //    {
        //        _roomName = value;
        //    }
        //}


        public String topic
        {
            get => _topic;
            set
            {
                _topic = value;
            }
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

        private void UpdateMeeting_Click(object sender, RoutedEventArgs e)
        {
            _startMeeting = dt;

            Room cboRoom = Rooms.SelectedItem as Room;
            _roomName = cboRoom.Name;

            _topic = Topics.Text;

            tempMeeting.Date = dt;
            tempMeeting.RoomName = _roomName;
            tempMeeting.Topic = _topic;

            Meeting m = _meetingRepository.UpdateMeeting(tempMeeting);


            NewMeet.Content = new Meetings();
        }
    }
}
