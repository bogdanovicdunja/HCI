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
    public class PatientRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _patientrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public PatientRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _patientrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Patient> patients)
        {
            return patients.Count() == 0 ? 0 : patients.Max(patient => patient.Id);
        }


        public Patient AddPatient(Patient patient)
        {
            patient.Id = ++_patientrMaxId;
            AppendLineToFile(_path, ConvertPatientToCSVFormat(patient));
            return patient;
        }

        public Patient GetPatient(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(patient => patient.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public Patient FindPatientByUsername(string username)
        {
            try
            {
                return GetAll().SingleOrDefault(user => user.Username == username);
            }
            catch (ArgumentException)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "username", username));
            }
        }

        public Patient UpdatePatient(Patient patient)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\patient.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertPatientToCSVFormat(patient);
                    Patient tempApp = ConvertCSVFormatToPatient(line);
                    if (patient.Id != tempApp.Id)
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



            return patient;
        }




        public Boolean RemovePatient(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Patient> patients = GetAll();

            patients = patients.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string patient_file = _projectPath + "\\Resources\\patient.txt";

            using (var sr = new StreamReader(patient_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Patient patient = ConvertCSVFormatToPatient(line);
                    if (patient.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(patient_file);
            File.Move(temp_file, patient_file);

            return retVal;
        }




        public IEnumerable<Patient> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToPatient)
             .ToList();
        }

        private Patient ConvertCSVFormatToPatient(string patientCSVFormat)
        {
            Patient patient = new Patient();
            string[] tokens = patientCSVFormat.Split(_delimeter.ToCharArray());
            // 1; DUNJICA; sssss; 02 - May - 22; s; sss; sss @gmail.com
            //4;ARSENIJE;Lalic;22-May-22;arsa;Svetozara Miletica 4;arsa@gmail.com
            uint Id = uint.Parse(tokens[0]);
            //string Username = tokens[1];
            //string Password = tokens[2];
            string Name = tokens[1];
            string Surname = tokens[2];
            //DateTime.Parse(tokens[4]);
            string DateOfBirth = tokens[3];
            string Username = tokens[4];
            string Adress = tokens[5];
            string Email = tokens[6];
            //Enum.TryParse(tokens[7], out Gender gender);
            // 

            return new Patient(
                Id,
                Name,
                Surname,
                //DateTime.Parse(tokens[8]),
                DateOfBirth,
                //Adress,
                //Email,
                ////gender,
                //Password,
                Username,
                Adress,
                Email
            );

        }


        private string ConvertPatientToCSVFormat(Patient patient)
        {
            return string.Join(_delimeter,
                patient.Id,
                //patient.Username,
                //patient.Password,
                patient.Name,
                patient.Surname,
                patient.DateOfBirth,
                patient.Username,
                patient.Adress,
                patient.Email
                //patient.Gender,
                
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
