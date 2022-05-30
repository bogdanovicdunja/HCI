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
    /// Interaction logic for AllPatients.xaml
    /// </summary>
    public partial class AllPatients : Page
    {
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string PATIENT_FILE = _projectPath + "\\Resources\\patients.txt";
        private const string CSV_DELIMITER = ";";
        public ObservableCollection<Patient> PatientList { get; set; }

        private PatientRepository _patientRepository;
        public AllPatients()
        {
            InitializeComponent();
          
            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);
            PatientList = new ObservableCollection<Patient>(_patientRepository.GetAll().ToList());


            for (int i = 0; i < PatientList.Count; i++)
            {
                GRD.Items.Add(PatientList[i]);
            }
        }

   

        private void ShowAllergens_Click(object sender, RoutedEventArgs e)
        {
            PatientFile.Navigate(new Allergens());
        }

    }
}
