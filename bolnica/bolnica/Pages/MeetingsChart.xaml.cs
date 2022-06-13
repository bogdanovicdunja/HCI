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
    /// Interaction logic for MeetingsChart.xaml
    /// </summary>
    public partial class MeetingsChart : Page
    {
        public SeriesCollection SeriesCollection { get; set; }
        public ObservableCollection<Meeting> MeetList { get; set; }

        public Dictionary<string, int> dict = new Dictionary<string, int>();
        public List<string> Names { get; set; }
        public MeetingsChart(ObservableCollection<Meeting> temp)
        {
            InitializeComponent();
            MeetList = temp;
            Names = getNames(MeetList);
            dict = fillDictionary(Names, MeetList);

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

                }
               
                           
            };

            DataContext = this;

         
        }


        public List<string> getNames(ObservableCollection<Meeting> Meetings)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Meetings.Count; i++)
            {
                string name = Meetings[i].RoomName;
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
            }

            return list;
        }

        public Dictionary<string, int> fillDictionary(List<string> names, ObservableCollection<Meeting> Meetings)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < names.Count; i++)
            {
                dict[names[i]] = 0;
            }
            for (int i = 0; i < Meetings.Count; i++)
            {
                dict[Meetings[i].RoomName]++;
            }
            return dict;
        }



    }
}
