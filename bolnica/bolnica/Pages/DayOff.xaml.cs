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
    /// Interaction logic for DayOff.xaml
    /// </summary>
    public partial class DayOff : Page
    {

        public ObservableCollection<DayOffRequest> DayOffList { get; set; }
       
        public DayOff()
        {
            InitializeComponent();
            GRD.Items.Clear();

            DayOffRequest day1 = new DayOffRequest(1, "Dunja", "Cardiology", "13/07/2022", "17/07/2022");
            DayOffRequest day2 = new DayOffRequest(2, "Olivera", "Oftalmology", "22/06/2022", "24/06/2022");
            DayOffRequest day3 = new DayOffRequest(3, "David", "Neurology", "09/08/2022", "15/09/2022");
            DayOffRequest day4 = new DayOffRequest(4, "Marko", "Dermatology", "10/10/2022", "11/10/2022");
            //DataContext = this;

     
            DayOffList = new ObservableCollection<DayOffRequest>();
            DayOffList.Add(day1);
            DayOffList.Add(day2);
            DayOffList.Add(day3);
            DayOffList.Add(day4);
          

            for(int i=0; i<DayOffList.Count; i++)
            {
                GRD.Items.Add(DayOffList[i]);   
            }

        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DayOffRequest dor = GRD.SelectedItem as DayOffRequest;

            for (int i = 0; i < DayOffList.Count; i++)
            {
                if (dor.Id == DayOffList[i].Id)
                {
                    GRD.Items.Remove(DayOffList[i]);
                    MessageBoxResult result = MessageBox.Show("Successfuly accepted request!");
                    return;         //obavezno! ne obrise bez toga.
                }
                
            }

        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            DayOffRequest dor = GRD.SelectedItem as DayOffRequest;

            for (int i = 0; i < DayOffList.Count; i++)
            {
                if (dor.Id == DayOffList[i].Id)
                {
                    GRD.Items.Remove(DayOffList[i]);
                    MessageBoxResult result = MessageBox.Show("Successfuly declined request!");
                    return;
                }
                
            }
        }
    }
}





