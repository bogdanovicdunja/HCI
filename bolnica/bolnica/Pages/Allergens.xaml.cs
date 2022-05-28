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
    /// Interaction logic for Allergens.xaml
    /// </summary>
    public partial class Allergens : Page
    {

        public ObservableCollection<Allergen> PatientAllergens;
        public Allergens()
        {
            InitializeComponent();

            Allergen a1 = new Allergen(1, "Pollen");
            Allergen a2 = new Allergen(2, "Mites");
            Allergen a3 = new Allergen(3, "Dust");
            Allergen a4 = new Allergen(4, "Ambrosia");
            Allergen a5 = new Allergen(5, "Lactose");

            GRD.Items.Add(a1);
            GRD.Items.Add(a2);
            GRD.Items.Add(a3);
            GRD.Items.Add(a4);
            GRD.Items.Add(a5);
        }

        private void ShowAllergens_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
