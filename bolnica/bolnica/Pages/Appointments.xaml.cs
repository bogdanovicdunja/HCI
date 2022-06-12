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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string APPOINTMENT_FILE = _projectPath + "\\Resources\\appointments.txt";
        private const string CSV_DELIMITER = ";";
        public ObservableCollection<Appointment> AppList { get; set; }

        private AppointmentRepository _appointmentRepository;


        public Appointments()
        {
            InitializeComponent();
            GRD.Items.Clear();
            //Appointment a1 = new Appointment(1, DateTime.Now, "nenad", "dunja", "soba 200");
            //DataContext = this;

           
            //if(appointment != null)
            //{
            //    AppList.Add(appointment);
            //    GRD.Items.Add(appointment);
            //}
            //AppList.Add(a1);
            //GRD.Items.Add(a1);
            _appointmentRepository = new AppointmentRepository(APPOINTMENT_FILE, CSV_DELIMITER);
            AppList = new ObservableCollection<Appointment>(_appointmentRepository.GetAll().ToList());

            for(int i = 0; i < AppList.Count; i++)
            {
                GRD.Items.Add(AppList[i]);
            }



        }


        private void ChartButton_Click(object sender, RoutedEventArgs e)
        {
            var page = new AppointmentChart(AppList);
            NavigationService.Navigate(page);
        }
        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            //AppFrame.Navigate(new NewAppointment());
            var page = new NewAppointment();
            NavigationService.Navigate(page);
        }

        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment ap = GRD.SelectedItem as Appointment;

            if (ap != null)
            {
                for (int i = 0; i < AppList.Count(); i++)
                {
                    if (AppList[i].Id == ap.Id)
                    {
                        GRD.Items.Remove(AppList[i]);
                    }
                }
            }

            //foreach(Appointment item in GRD.SelectedItems)
            //{
            //    GRD.Items.Remove(item);
            //}


        }

        private void UpdateAppointment_Click(object sender, RoutedEventArgs e)
        {
            Appointment ap = GRD.SelectedItem as Appointment;
            AppFrame.Navigate(new UpdateAppointment(ap));
        }

    }
}
