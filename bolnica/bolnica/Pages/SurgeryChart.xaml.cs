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
    /// Interaction logic for SurgeryChart.xaml
    /// </summary>
    public partial class SurgeryChart : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<Model.Surgery> SurList { get; set; }

        public Dictionary<string, int> dict = new Dictionary<string, int>();
        public List<string> Names { get; set; }

        public SurgeryChart(ObservableCollection<Model.Surgery> temp)
        {
            InitializeComponent();
            SurList = temp;
            Names = getNames(SurList);
            dict = fillDictionary(Names, SurList);
            
            SeriesCollection = new SeriesCollection
            {
               
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

                }
               
                    
               
            };

            DataContext = this;
        }

        public List<string> getNames(ObservableCollection<Model.Surgery> Surgeries)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Surgeries.Count; i++)
            {
                string name = Surgeries[i].DoctorName;
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
            }

            return list;
        }

        public Dictionary<string, int> fillDictionary(List<string> names, ObservableCollection<Model.Surgery> Surgeries)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < names.Count; i++)
            {
                dict[names[i]] = 0;
            }
            for (int i = 0; i < Surgeries.Count; i++)
            {
                dict[Surgeries[i].DoctorName]++;
            }
            return dict;
        }
    }
}
