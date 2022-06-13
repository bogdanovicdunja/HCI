using bolnica.Model;
using bolnica.Repository;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Drawing;
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
    /// Interaction logic for NewSuergery.xaml
    /// </summary>
    public partial class NewSurgery : Page
    {

        private DateTime _startAppointment;
        private string _patientName;
        private string _doctorName;
        private string _roomName;

        public string t = "";
        public string d = "";
        DateTime dt;
        DateTime test;

        private PatientRepository _patientRepository;
        private DoctorRepository _doctorRepository;
        private RoomRepository _roomRepository;
        private AppointmentRepository _appointmentRepository;

        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
          .Split(new string[] { "bin" }, StringSplitOptions.None)[0];

        private string PATIENT_FILE = _projectPath + "\\Resources\\patients.txt";
        private string DOCTOR_FILE = _projectPath + "\\Resources\\doctors.txt";
        private string ROOM_FILE = _projectPath + "\\Resources\\rooms.txt";
        private string SURGERY_FILE = _projectPath + "\\Resources\\surgery.txt";
        private const string CSV_DELIMITER = ";";

        public ObservableCollection<Patient> PatientsList { get; set; }  //NE MOZE ISTO KAO NA FRONTENDU
        public ObservableCollection<Doctor> DoctorsList { get; set; }
        public ObservableCollection<Room> RoomsList { get; set; }

        public NewSurgery()
        {
            InitializeComponent();
            DataContext = this;

            _patientRepository = new PatientRepository(PATIENT_FILE, CSV_DELIMITER);
            _doctorRepository = new DoctorRepository(DOCTOR_FILE, CSV_DELIMITER);
            _roomRepository = new RoomRepository(ROOM_FILE, CSV_DELIMITER);
            _appointmentRepository = new AppointmentRepository(SURGERY_FILE, CSV_DELIMITER);

            PatientsList = new ObservableCollection<Patient>(_patientRepository.GetAll().ToList());
            DoctorsList = new ObservableCollection<Doctor>(_doctorRepository.GetAll().ToList());
            RoomsList = new ObservableCollection<Room>(_roomRepository.GetAll().ToList());

            Patients.ItemsSource = PatientsList;    //Patients - combobox sa frontenda
            Doctors.ItemsSource = DoctorsList;
            Rooms.ItemsSource = RoomsList;
        }

        private void DP1_SelectedDateChanged(object sender, RoutedEventArgs e)
        {           
            d = DP1.Text;
  
        }

        private void cboTP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cboitem = cboTP.SelectedItem as ComboBoxItem;
            t = cboitem.Content.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //_startAppointment = dt; //**************************************** DATUM VALIDACIJA
            if (d == "")
            {
                MessageBoxResult sz = MessageBox.Show("select a date");
                return;
            }

            if (t == "")
            {
                MessageBoxResult result = MessageBox.Show("Select a time");
                return;
            }


            dt = DateTime.Parse(d + " " + t);

            if (dt == test)
            {
                MessageBoxResult z = MessageBox.Show("select a date");
                return;
            }


            if (Rooms.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Room must be selected!");
                return;
            }
            Room cboRoom = Rooms.SelectedItem as Room;
            _roomName = cboRoom.Name;



            if (Patients.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Patient must be selected!");
                return;
            }
            Patient cboPatient = Patients.SelectedItem as Patient;
            _patientName = cboPatient.Name;




            if (Doctors.SelectedItem == null)
            {
                MessageBoxResult result = MessageBox.Show("Doctor must be selected!");
                return;
            }
            Doctor cboDoctor = Doctors.SelectedItem as Doctor;
            _doctorName = cboDoctor.Name;


            

            Appointment appointment = new Appointment(dt, _patientName, _doctorName, _roomName);
            Appointment a = _appointmentRepository.AddAppointment(appointment);

        
            var page = new Surgery();
            NavigationService.Navigate(page);
        }


        public void SendMessage()
        {
            MessageBox.Show("Report is successfully created!");
        }

        public void Report_Click(object sender, RoutedEventArgs e)
        {
            GeneratePDF();
            SendMessage();
        }

        public void GeneratePDF()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.Pages.Add();
                PdfGraphics graphics = page.Graphics;
                PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
                PdfFont font1 = new PdfStandardFont(PdfFontFamily.Helvetica, 15);
                string naslov = "Hospital Health";
                
                graphics.DrawString(naslov, font, PdfBrushes.Black, new PointF(200, 0));
                string textPDF = "Report abaout room occupation for date you chose: ";
                graphics.DrawString(textPDF, font1, PdfBrushes.Black, new PointF(80, 75));
                PdfLightTable pdfLightTable = new PdfLightTable();
                DataTable table = new DataTable();
               
                table.Columns.Add("Room Name");
                table.Columns.Add("Period");
                table.Columns.Add("Doctor");

                table.Rows.Add(new string[] { "room 202", "10:00h", "Dr Nikolina" });
                table.Rows.Add(new string[] { "room 202", "10:30h", "Dr Sandra" });
                table.Rows.Add(new string[] { "room 202", "12:00h", "Dr Sava" });
                table.Rows.Add(new string[] { "room 303", "08:00h", "Dr Dunja" });
                table.Rows.Add(new string[] { "room 303", "08:30h", "Dr Nikolina" });
                table.Rows.Add(new string[] { "room 303", "09:15h", "Dr Maksim" });
                table.Rows.Add(new string[] { "room 404", "10:00h", "Dr Dunja" });
                table.Rows.Add(new string[] { "room 404", "10:30h", "Dr Olivera" });
                table.Rows.Add(new string[] { "room 404", "12:00h", "Dr Adrijana" });
                table.Rows.Add(new string[] { "room 505", "08:00h", "Dr Zoran" });
                table.Rows.Add(new string[] { "room 505", "08:30h", "Dr Svetlana" });
                table.Rows.Add(new string[] { "room 505", "08:45h", "Dr Andrej" });
                table.Rows.Add(new string[] { "room 606", "13:00h", "Dr Aleksandar" });
                table.Rows.Add(new string[] { "room 606", "14:30h", "Dr Marko" });
                table.Rows.Add(new string[] { "room 606", "15:00h", "Dr Ivan" });


                pdfLightTable.DataSource = table;
                pdfLightTable.Style.ShowHeader = true;
                pdfLightTable.Draw(page, new PointF(0, 100));
                doc.Save(@"C:\Users\dunja\Desktop\HCI\bolnica\bolnica\Reports\RoomOccupation.pdf");
               
                doc.Close(true);


            }
        }
    }
}
