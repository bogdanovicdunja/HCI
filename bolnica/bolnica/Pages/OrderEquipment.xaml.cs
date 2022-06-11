using bolnica.Repository;
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
    /// Interaction logic for OrderEquipment.xaml
    /// </summary>
    public partial class OrderEquipment : Page
    {

        public string _kindOfEquipment;
        public int _amountOfEquipment;

        private EquipmentRepository _equipmentRepository;

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
         .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string EQUIPMENT_FILE = _projectPath + "\\Resources\\equipment.txt";
        private const string CSV_DELIMITER = ";";
        
        public OrderEquipment()
        {
            InitializeComponent();
            DataContext = this;
            _equipmentRepository = new EquipmentRepository(EQUIPMENT_FILE, CSV_DELIMITER);
           
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Kinds.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Equipment type must be selected!");
                return;
            }
            ComboBoxItem cboKind = Kinds.SelectedItem as ComboBoxItem;
            _kindOfEquipment = cboKind.Content.ToString();

            try
            {
                _amountOfEquipment = Convert.ToInt32(Amount.Text);
            }
            catch
            {
                MessageBoxResult result = MessageBox.Show("Amount can't be empty or a string!");
            }
            if (_amountOfEquipment <= 0)
            {
                MessageBoxResult result = MessageBox.Show("Amount must be positive integer!");
                return;
            }

          


            Model.Equipment equipment = new Model.Equipment(_kindOfEquipment, _amountOfEquipment);
            Model.Equipment eq = _equipmentRepository.AddEquipment(equipment);


            //NewMeet.Content = new Meetings();
            var page = new Equipment();
            NavigationService.Navigate(page);
        }
    }
}
