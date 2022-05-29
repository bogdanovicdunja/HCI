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
    /// Interaction logic for Appointments.xaml
    /// </summary>
    public partial class Appointments : Page
    {

        public ObservableCollection<Appointment> AppList { get; set; }
        public Appointments(Appointment appointment)
        {
            InitializeComponent();
            Appointment a1 = new Appointment(1, DateTime.Now, "nenad", "dunja", "soba 200");
            AppList = new ObservableCollection<Appointment>();
            if(appointment != null)
            {
                AppList.Add(appointment);
                GRD.Items.Add(appointment);
            }
            AppList.Add(a1);
            GRD.Items.Add(a1);

        }


        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.Navigate(new NewAppointment());
        }

        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
