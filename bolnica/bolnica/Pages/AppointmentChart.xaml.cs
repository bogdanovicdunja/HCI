using bolnica.Model;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
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
    /// Interaction logic for AppointmentChart.xaml
    /// </summary>
    public partial class AppointmentChart : Page
    {
        public SeriesCollection SeriesCollection { get; set; }

        public ObservableCollection<Appointment> AppList { get; set; }
        public Dictionary<string, int> dict =
                       new Dictionary<string, int>();
        public List<string> Names { get; set; }
        public AppointmentChart(ObservableCollection<Appointment> temp)


        {

            InitializeComponent();
            AppList = temp;
            Names = getNames(AppList);
            dict = fillDictionary(Names, AppList);
           // AppList = temp;
            SeriesCollection = new SeriesCollection
            {
                //for (int i = 0; i < AppList.Count; i++)
                //{
                new PieSeries
                {
                    Title = Names[0],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[0]]) },
                    DataLabels = true

                },  new PieSeries
                {
                    Title = Names[1],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[1]]) },
                    DataLabels = true

                },  new PieSeries
                {
                    Title = Names[2],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[2]]) },
                    DataLabels = true

                },  new PieSeries
                {
                    Title = Names[3],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[3]]) },
                    DataLabels = true

                },  new PieSeries
                {
                    Title = Names[4],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[4]]) },
                    DataLabels = true

                },  new PieSeries
                {
                    Title = Names[5],
                    Values = new ChartValues<ObservableValue> { new ObservableValue(dict[Names[5]]) },
                    DataLabels = true

                }
                    
                //}d
            };
            //    new PieSeries
            //    {
            //        Title = "Chrome",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(8) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Mozilla",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(6) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Opera",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(10) },
            //        DataLabels = true
            //    },
            //    new PieSeries
            //    {
            //        Title = "Explorer",
            //        Values = new ChartValues<ObservableValue> { new ObservableValue(4) },
            //        DataLabels = true
            //    }
            //};
            DataContext = this;

        }

        public List<string> getNames(ObservableCollection<Appointment> Appointments)
        {
            List<string> list = new List<string>();
            for(int i = 0; i < Appointments.Count; i++)
            {
                string name = Appointments[i].DoctorName;
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
            }

            return list;
        }

        public Dictionary<string, int> fillDictionary(List<string> names, ObservableCollection<Appointment> Appointments)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < names.Count; i++)
            {
                dict[names[i]] = 0;
            }
            for(int i = 0; i < Appointments.Count; i++)
            {
                dict[Appointments[i].DoctorName]++;
            }
            return dict;
        }
    }
}
