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
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Surgery : Page
    {
        public Surgery()
        {
            InitializeComponent();
        }

        private void AddSurgery_Click(object sender, RoutedEventArgs e)
        {
            SurFrame.Navigate(new NewSurgery());
        }

        private void DeleteSurgery_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
