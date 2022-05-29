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
    public class DoctorRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _doctorrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public DoctorRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _doctorrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Doctor> doctors)
        {
            return doctors.Count() == 0 ? 0 : doctors.Max(doctor => doctor.Id);
        }


        public Doctor AddDoctor(Doctor doctor)
        {
            doctor.Id = ++_doctorrMaxId;
            AppendLineToFile(_path, ConvertDoctorToCSVFormat(doctor));
            return doctor;
        }

        public Doctor GetDoctor(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(doctor => doctor.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Doctor FindDoctorByUsername(string username)
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

        public Doctor UpdateDoctor(Doctor doctor)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\doctor.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertDoctorToCSVFormat(doctor);
                    Doctor tempApp = ConvertCSVFormatToDoctor(line);
                    if (doctor.Id != tempApp.Id)
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



            return doctor;
        }




        public Boolean RemoveDoctor(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Doctor> doctors = GetAll();

            doctors = doctors.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string doctor_file = _projectPath + "\\Resources\\doctor.txt";

            using (var sr = new StreamReader(doctor_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Doctor doctor = ConvertCSVFormatToDoctor(line);
                    if (doctor.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(doctor_file);
            File.Move(temp_file, doctor_file);

            return retVal;
        }




        public IEnumerable<Doctor> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToDoctor)
             .ToList();
        }

        private Doctor ConvertCSVFormatToDoctor(string doctorCSVFormat)
        {
            Doctor doctor = new Doctor();
            string[] tokens = doctorCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            //string Username = tokens[1];
            //string Password = tokens[2];
            string Name = tokens[1];
            //string Surname = tokens[2];
            //string Username = tokens[3];
            //string Adress = tokens[4];
            //string Email = tokens[5];
            //Enum.TryParse(tokens[7], out Gender gender);
            // DateTime.Parse(tokens[8]);

            return new Doctor(
                Id,
                Name
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


        private string ConvertDoctorToCSVFormat(Doctor doctor)
        {
            return string.Join(_delimeter,
                doctor.Id,
                //doctor.Username,
                //doctor.Password,
                doctor.Name
                //doctor.Surname,
                //doctor.Username,
                //doctor.Adress,
                //doctor.Email
                //doctor.Gender,
                //doctor.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
