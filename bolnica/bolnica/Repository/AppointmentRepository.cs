using bolnica.Exception;
using bolnica.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Repository
{
    public class AppointmentRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _appointmentrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public AppointmentRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _appointmentrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Appointment> appointments)
        {
            return appointments.Count() == 0 ? 0 : appointments.Max(appointment => appointment.Id);
        }


        public Appointment AddAppointment(Appointment appointment)
        {
            appointment.Id = ++_appointmentrMaxId;
            AppendLineToFile(_path, ConvertAppointmentToCSVFormat(appointment));
            return appointment;
        }

        public Appointment GetAppointment(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(appointment => appointment.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Appointment FindAppointmentByUsername(string username)
        //{
        //    try
        //    {
        //        return GetAll().SingleOrDefault(user => user.Username == username);
        //    }
        //    catch (ArgumentException)
        //    {
        //        throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "username", username));
        //    }
        //}

        public Appointment UpdateAppointment(Appointment appointment)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\appointments.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertAppointmentToCSVFormat(appointment);
                    Appointment tempApp = ConvertCSVFormatToAppointment(line);
                    if (appointment.Id != tempApp.Id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                    }
                    //sw.WriteLine(lineToWrite);
                }
            }
            File.Delete(_file);
            File.Move(temp_file, _file);



            return appointment;
        }




        public Boolean RemoveAppointment(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Appointment> appointments = GetAll();

            appointments = appointments.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string appointment_file = _projectPath + "\\Resources\\appointments.txt";

            using (var sr = new StreamReader(appointment_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Appointment appointment = ConvertCSVFormatToAppointment(line);
                    if (appointment.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(appointment_file);
            File.Move(temp_file, appointment_file);

            return retVal;
        }




        public IEnumerable<Appointment> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToAppointment)
             .ToList();
        }

        private Appointment ConvertCSVFormatToAppointment(string appointmentCSVFormat)
        {
            Appointment appointment = new Appointment();
            string[] tokens = appointmentCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            //string Username = tokens[1];
            //string Password = tokens[2];
            //string Name = tokens[2];
            //string Surname = tokens[2];
            //string Username = tokens[3];
            //string Adress = tokens[4];
            //string Email = tokens[5];
            //Enum.TryParse(tokens[7], out Gender gender);
            DateTime.Parse(tokens[1]);
            string PatientName = tokens[2];
            string DoctorName = tokens[3];
            string RoomName = tokens[4];

            return new Appointment(
                Id,
                DateTime.Parse(tokens[1]),
                PatientName,
                DoctorName,
                RoomName
            //Surname,
            ////DateTime.Parse(tokens[8]),
            ////Adress,
            ////Email,
            //////gender,
            ////Password,
            //Username,
            //Adress,
            //Email
            );

        }


        private string ConvertAppointmentToCSVFormat(Appointment appointment)
        {
            return string.Join(_delimeter,
                appointment.Id,
                appointment.Start,
                //appointment.Username,
                //appointment.Password,
                appointment.PatientName,
                appointment.DoctorName,
                appointment.RoomName
                //appointment.Surname,
                //appointment.Username,
                //appointment.Adress,
                //appointment.Email
                //appointment.Gender,
                //appointment.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
