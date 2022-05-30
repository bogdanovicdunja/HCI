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
    /// Interaction logic for Allergens.xaml
    /// </summary>
    public partial class Allergens : Page
    {

        

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string ALLERGEN_FILE = _projectPath + "\\Resources\\allergens.txt";
        private const string CSV_DELIMITER = ";";
       
        private AllergenRepository _allergenRepository;

        public ObservableCollection<Allergen> AllergenList { get; set; }


        public Allergens()
        {
            InitializeComponent();

            _allergenRepository = new AllergenRepository(ALLERGEN_FILE, CSV_DELIMITER);
            AllergenList = new ObservableCollection<Allergen>(_allergenRepository.GetAll().ToList());

            for (int i = 0; i < AllergenList.Count; i++)
            {
                GRD.Items.Add(AllergenList[i]);
            }

            //READ ALLERGEN-A   ****
        }
    

        private void AddAllergens_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void DeleteAllergens_Click(object sender, RoutedEventArgs e)
        {
            Allergen all = GRD.SelectedItem as Allergen;

            if (all != null)
            {
                for (int i = 0; i < AllergenList.Count(); i++)
                {
                    if (AllergenList[i].Id == all.Id)
                    {
                        GRD.Items.Remove(AllergenList[i]);
                    }
                }
            }
        }
    }
}
