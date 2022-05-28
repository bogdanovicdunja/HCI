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
    /// Interaction logic for AllPatients.xaml
    /// </summary>
    public partial class AllPatients : Page
    {

        public ObservableCollection<Patient> PatientList { get; set; }
        public AllPatients()
        {
            InitializeComponent();
            Patient p1 = new Patient("Ana", "Anic", "ana", "Majevicka 5", "ana@gmail.com");
            Patient p2 = new Patient("Mina", "Minic", "mina", "Hajduk Veljkova 23", "mina@gmail.com");
            Patient p3 = new Patient("Nikola", "Nikolic", "nikola", "Beogradska 7", "nikola@gmail.com");
            Patient p4 = new Patient("Marko", "Markovic", "marko", "Cara Lazara 14", "marko@gmail.com");
            Patient p5 = new Patient("Sanja", "Sanjic", "sanja", "Rumenacka 9", "sanja@gmail.com");

            PatientList = new ObservableCollection<Patient>();
            PatientList.Add(p1);
            PatientList.Add(p2);
            PatientList.Add(p3);
            PatientList.Add(p4);
            PatientList.Add(p5);


            for(int i = 0; i < PatientList.Count; i++)
            {
                GRD.Items.Add(PatientList[i]);
            }
        }

        public List<Patient> GetPatients()
        {
            List<Patient> patients = new List<Patient>();
            Patient p1 = new Patient("Ana", "Anic", "ana", "Majevicka 5", "ana@gmail.com");
            Patient p2 = new Patient("Mina", "Minic", "mina", "Hajduk Veljkova 23", "mina@gmail.com");
            Patient p3 = new Patient("Nikola", "Nikolic", "nikola", "Beogradska 7", "nikola@gmail.com");

            patients.Add(p1);
            patients.Add(p2);
            patients.Add(p3);

            return patients;
        }

        /*private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }*/

        private void ShowAllergens_Click(object sender, RoutedEventArgs e)
        {
            PatientFile.Navigate(new Allergens());
        }

    }
}
