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
    /// Interaction logic for Guesst.xaml
    /// </summary>
    public partial class Guesst : Page
    {
        public Guesst()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void CreateButton(object sender, RoutedEventArgs e)
        {
            //GuesstAcc.Content = new Emergency();
            var page = new Emergency();
            NavigationService.Navigate(page);

        }

        
    }
}
