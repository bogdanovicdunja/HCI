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
    public class SurgeryRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _surgeryrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public SurgeryRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _surgeryrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Surgery> surgerys)
        {
            return surgerys.Count() == 0 ? 0 : surgerys.Max(surgery => surgery.Id);
        }


        public Surgery AddSurgery(Surgery surgery)
        {
            surgery.Id = ++_surgeryrMaxId;
            AppendLineToFile(_path, ConvertSurgeryToCSVFormat(surgery));
            return surgery;
        }

        public Surgery GetSurgery(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(surgery => surgery.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Surgery FindSurgeryByUsername(string username)
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

        public Surgery UpdateSurgery(Surgery surgery)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\surgery.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertSurgeryToCSVFormat(surgery);
                    Surgery tempApp = ConvertCSVFormatToSurgery(line);
                    if (surgery.Id != tempApp.Id)
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



            return surgery;
        }




        public Boolean RemoveSurgery(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Surgery> surgerys = GetAll();

            surgerys = surgerys.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string surgery_file = _projectPath + "\\Resources\\surgery.txt";

            using (var sr = new StreamReader(surgery_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Surgery surgery = ConvertCSVFormatToSurgery(line);
                    if (surgery.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(surgery_file);
            File.Move(temp_file, surgery_file);

            return retVal;
        }




        public IEnumerable<Surgery> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToSurgery)
             .ToList();
        }

        private Surgery ConvertCSVFormatToSurgery(string surgeryCSVFormat)
        {
            Surgery surgery = new Surgery();
            string[] tokens = surgeryCSVFormat.Split(_delimeter.ToCharArray());

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

            return new Surgery(
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


        private string ConvertSurgeryToCSVFormat(Surgery surgery)
        {
            return string.Join(_delimeter,
                surgery.Id,
                surgery.Start,
                //surgery.Username,
                //surgery.Password,
                surgery.PatientName,
                surgery.DoctorName,
                surgery.RoomName
                //surgery.Surname,
                //surgery.Username,
                //surgery.Adress,
                //surgery.Email
                //surgery.Gender,
                //surgery.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}

