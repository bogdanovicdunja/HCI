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
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Surgery : Page
    {

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string SURGERY_FILE = _projectPath + "\\Resources\\surgery.txt";
        private const string CSV_DELIMITER = ";";
        public ObservableCollection<Model.Surgery> SurList { get; set; }

        private SurgeryRepository _surgeryRepository;


        public Surgery()
        {
            InitializeComponent();
            GRD.Items.Clear();


            _surgeryRepository = new SurgeryRepository(SURGERY_FILE, CSV_DELIMITER);
            SurList = new ObservableCollection<Model.Surgery>(_surgeryRepository.GetAll().ToList());

            for (int i = 0; i < SurList.Count; i++)
            {
                GRD.Items.Add(SurList[i]);
            }
        }

        private void AddSurgery_Click(object sender, RoutedEventArgs e)
        {
            //SurFrame.Navigate(new NewSurgery());
            var page = new NewSurgery();
            NavigationService.Navigate(page);
        }


        private void DeleteSurgery_Click(object sender, RoutedEventArgs e)
        {
            Model.Surgery sur = GRD.SelectedItem as Model.Surgery;

            if (sur != null)
            {
                for (int i = 0; i < SurList.Count(); i++)
                {
                    if (SurList[i].Id == sur.Id)
                    {
                        GRD.Items.Remove(SurList[i]);
                    }
                }
            }
        }


        private void UpdateSurgery_Click(object sender, RoutedEventArgs e)
        {
            Model.Surgery sur = GRD.SelectedItem as Model.Surgery;
            SurFrame.Navigate(new UpdateSurgery(sur));
        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            var page = new SurgeryChart(SurList);
            NavigationService.Navigate(page);
        }

    }
}
