using LiveCharts;
using LiveCharts.Configurations;
using LiveCharts.Helpers;
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
    /// Interaction logic for EquipmentChart.xaml
    /// </summary>
    public partial class EquipmentChart : Page
    {
        public Dictionary<string, int> dict =
                      new Dictionary<string, int>();
        public List<string> Names { get; set; }
        public List<Model.Equipment> EquipmentList { get; set; }

        public ChartValues<Model.Equipment> Results { get; set; }
        public ObservableCollection<string> Labels { get; set; }
        public Func<double, string> MillionFormatter { get; set; }

        public ObservableCollection<Model.Equipment> OrderList { get; set; }

        public object Mapper { get; set; }

        public EquipmentChart(ObservableCollection<Model.Equipment> temp)
        {
            
            InitializeComponent();
            OrderList = temp;
            //Names = getNames(OrderList);
            EquipmentList = getEquipmentNames(OrderList);
            //dict = fillDictionary(Names, OrderList);
            OrderList = temp;
            EquipmentList = fillEquipment(EquipmentList, OrderList);

            //lets configure the chart to plot cities
         

            //lets take the first 15 records by default;
            //var records = OrderList.Equ.OrderByDescending(x => x.Quantity).Take(15).ToArray();
            var records = EquipmentList;

            Mapper = Mappers.Xy<Model.Equipment>()
             .X((city, index) => index)
             .Y(city => city.Quantity);

            Results = records.AsChartValues();
            Labels = new ObservableCollection<string>(records.Select(x => x.Name));

            // MillionFormatter = value => (value / 1).ToString("N") + "M";

            DataContext = this;
        }


            

            //private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
            //{
            //    var q = (Query.Text ?? string.Empty).ToUpper();

            ////var records = DataBase.Cities
            ////    .Where(x => x.Name.ToUpper().Contains(q) || x.Country.ToUpper().Contains(q))
            ////    .OrderByDescending(x => x.Population)
            ////    .Take(15)
            ////    .ToArray();

            //    //OrderList = temp;
            //    var records = OrderList;

            //    Results.Clear();
            //    Results.AddRange(records);

            //    Labels.Clear();
            //    foreach (var record in records) Labels.Add(record.Name);

            //}


        public List<string> getNames(ObservableCollection<Model.Equipment> Equipments)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Equipments.Count; i++)
            {
                string name = Equipments[i].Name;
                if (!list.Contains(name))
                {
                    list.Add(name);
                }
            }

            return list;
        }

        public List<Model.Equipment> getEquipmentNames(ObservableCollection<Model.Equipment> Equipments)
        {
            List<Model.Equipment> list = new List<Model.Equipment>();
            for (int i = 0; i < Equipments.Count; i++)
            {
                string name = Equipments[i].Name;
                int flag = 0;
                for(int j=0; j<list.Count; j++)
                {
                    if(list[j].Name == name)
                    {
                        flag = 1;
                        break;
                    }
                }
                if (flag == 0)
                {
                    //Equipments[i].Quantity = 0;
                    list.Add(Equipments[i]);
                }
            }


            //MessageBoxResult result = MessageBox.Show(list.Count.ToString());

            return list;
        }

        public Dictionary<string, int> fillDictionary(List<string> names, ObservableCollection<Model.Equipment> Equipments)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < names.Count; i++)
            {
                dict[names[i]] = 0;
            }
            for (int i = 0; i < Equipments.Count; i++)
            {
                dict[Equipments[i].Name]+= Equipments[i].Quantity;
            }
            return dict;
        }

        public List<Model.Equipment> fillEquipment(List<Model.Equipment> equipments, ObservableCollection<Model.Equipment> Equipments)
        {
            
            List<Model.Equipment> retVal;
                      

            for(int i=0; i<equipments.Count; i++)
            {
                for(int j=0; j<Equipments.Count; j++)
                {
                    if (Equipments[j].Name == equipments[i].Name && Equipments[j].Quantity != equipments[i].Quantity)
                    {
                        equipments[i].Quantity += Equipments[j].Quantity;
                    }
                }
            }

            retVal = equipments;
            return retVal;
        }

    }
}
