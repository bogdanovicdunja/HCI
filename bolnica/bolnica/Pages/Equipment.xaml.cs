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
    /// Interaction logic for Equipment.xaml
    /// </summary>
    public partial class Equipment : Page
    {

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
         .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string EQUIPMENT_FILE = _projectPath + "\\Resources\\equipment.txt";
        private const string CSV_DELIMITER = ";";
        public ObservableCollection<Model.Equipment> OrderList { get; set; }

        private EquipmentRepository _equipmentRepository;

        public Equipment()
        {
            InitializeComponent();

            _equipmentRepository = new EquipmentRepository(EQUIPMENT_FILE, CSV_DELIMITER);
            OrderList = new ObservableCollection<Model.Equipment>(_equipmentRepository.GetAll().ToList());


            for (int i = 0; i < OrderList.Count; i++)
            {
                GRD.Items.Add(OrderList[i]);
            }
        }


        private void NewOrder_Click(object sender, RoutedEventArgs e)
        {
            var page = new OrderEquipment();
            NavigationService.Navigate(page);
        }

        private void Chart_Click(object sender, RoutedEventArgs e)
        {
            var page = new EquipmentChart(OrderList);
            NavigationService.Navigate(page);
        }
    }
}
