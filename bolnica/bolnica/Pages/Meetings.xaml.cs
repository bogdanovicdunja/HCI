using bolnica.Model;
using bolnica.Repository;
using bolnica.ViewModel;
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
    /// Interaction logic for Meetings.xaml
    /// </summary>
    public partial class Meetings : Page
    {

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string MEETING_FILE = _projectPath + "\\Resources\\meetings.txt";
        private const string CSV_DELIMITER = ";";
        public ObservableCollection<Meeting> MeetList { get; set; }

        private MeetingRepository _meetingRepository;


        public Meetings()
        {
            InitializeComponent();
            //this.DataContext = new MeetingsListingVM();
            GRD.Items.Clear();

            _meetingRepository = new MeetingRepository(MEETING_FILE, CSV_DELIMITER);
            MeetList = new ObservableCollection<Meeting>(_meetingRepository.GetAll().ToList());

            for (int i = 0; i < MeetList.Count; i++)
            {
                GRD.Items.Add(MeetList[i]);
            }

        }


        private void DeleteMeeting_Click(object sender, RoutedEventArgs e)
        {
            Meeting meet = GRD.SelectedItem as Meeting;

            if (meet != null)
            {
                for (int i = 0; i < MeetList.Count(); i++)
                {
                    if (MeetList[i].Id == meet.Id)
                    {
                        GRD.Items.Remove(MeetList[i]);
                    }
                }
                //_meetingRepository.RemoveMeeting(meet.Id);
            }

        }

        private void UpdateMeeting_Click(object sender, RoutedEventArgs e)
        {
            Meeting m = GRD.SelectedItem as Meeting;
            MeetingFile.Navigate(new UpdateMeeting(m));

        }

         private void Chart_Click(object sender, RoutedEventArgs e)
        {
            var page = new MeetingsChart(MeetList);
            NavigationService.Navigate(page);

        }

    private void AddMeeting_Click(object sender, RoutedEventArgs e)
        {
            
            var page = new NewMeeting();
            NavigationService.Navigate(page);
        }
    }
}
