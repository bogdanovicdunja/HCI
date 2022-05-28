using bolnica.Model;
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

        //public ObservableCollection<Meeting> MeetingList { get; set; }


        public Meetings()
        {
            InitializeComponent();

            Meeting m1 = new Meeting(1, "23/05/2022", "14:30", "202", "Lack of staff");
            Meeting m2 = new Meeting(2, "05/06/2022", "16:00", "100", "Vacation");
            Meeting m3 = new Meeting(3, "17/06/2022", "10:00", "404", "Seminars");
            Meeting m4 = new Meeting(4, "12/07/2022", "17:00", "305", "Duty");
            Meeting m5 = new Meeting(5, "02/08/2022", "11:15", "202", "Specialization");

            GRD.Items.Add(m1);
            GRD.Items.Add(m2);
            GRD.Items.Add(m3);
            GRD.Items.Add(m4);
            GRD.Items.Add(m5);

        }


        private void DeleteMeeting_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void AddMeeting_Click(object sender, RoutedEventArgs e)
        {
            MeetingFile.Navigate(new NewMeeting());
        }
    }
}
