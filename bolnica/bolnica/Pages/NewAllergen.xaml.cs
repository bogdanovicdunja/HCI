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
    /// Interaction logic for NewAllergen.xaml
    /// </summary>
    public partial class NewAllergen : Page
    {
        public NewAllergen()
        {
            InitializeComponent();
            DataContext = this;
        }


        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (allergies.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Allergen must be selected!");
                return;
            }
            var page = new Allergens();
            NavigationService.Navigate(page);
        }
}
}
