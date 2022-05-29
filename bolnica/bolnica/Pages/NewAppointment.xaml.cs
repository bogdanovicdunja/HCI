using bolnica.Model;
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
    /// Interaction logic for NewAppointment.xaml
    /// </summary>
    public partial class NewAppointment : Page
    {

        private DateTime _startAppointment;
        private string _timeAppointment;
        private string _patientUsername;
        private string _doctorUsername;
        private string _roomName;

        public string t;
        public string d;
        DateTime dt;
        public NewAppointment()
        {
            InitializeComponent();
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

            ComboBoxItem cboPatient = Patients.SelectedItem as ComboBoxItem;
            _patientUsername = cboPatient.Content.ToString();

            ComboBoxItem cboDoctor = Doctors.SelectedItem as ComboBoxItem;
            _doctorUsername = cboDoctor.Content.ToString();

            ComboBoxItem cboRoom = Rooms.SelectedItem as ComboBoxItem;
            _roomName = cboRoom.Content.ToString();

            Appointment appointment = new Appointment(_startAppointment, _patientUsername, _doctorUsername, _roomName);


            //public Appointments(Appointment appointment);
                
                NewApp.Content = new Appointments(appointment);    //vodi na stranicu sa svim zakazanim pregledima
        }
    }
}
