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
    public class SecretaryRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _secretaryrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public SecretaryRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _secretaryrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Secretary> secretarys)
        {
            return secretarys.Count() == 0 ? 0 : secretarys.Max(secretary => secretary.Id);
        }


        public Secretary AddSecretary(Secretary secretary)
        {
            secretary.Id = ++_secretaryrMaxId;
            AppendLineToFile(_path, ConvertSecretaryToCSVFormat(secretary));
            return secretary;
        }

        public Secretary GetSecretary(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(secretary => secretary.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        public Secretary FindSecretaryByUsername(string username)
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

        //public Secretary UpdateSecretary(Secretary secretary)
        //{
        //    string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
        //    string _file = _projectPath + "\\Resources\\secretary.txt";


        //    using (var sr = new StreamReader(_file))
        //    using (var sw = new StreamWriter(temp_file))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            string lineToWrite = ConvertSecretaryToCSVFormat(secretary);
        //            Secretary tempApp = ConvertCSVFormatToSecretary(line);
        //            if (secretary.Id != tempApp.Id)
        //            {
        //                sw.WriteLine(line);
        //            }
        //            else
        //            {
        //                sw.WriteLine(lineToWrite);
        //            }
        //            //sw.WriteLine(lineToWrite);
        //        }
        //    }
        //    File.Delete(_file);
        //    File.Move(temp_file, _file);



        //    return secretary;
        //}




        //public Boolean RemoveSecretary(uint id)
        //{
        //    Boolean retVal = false;
        //    IEnumerable<Secretary> secretarys = GetAll();

        //    secretarys = secretarys.Where(a => a.Id != id).ToList();

        //    string temp_file = _projectPath + "\\Resources\\tempPat.txt";
        //    string secretary_file = _projectPath + "\\Resources\\secretary.txt";

        //    using (var sr = new StreamReader(secretary_file))
        //    using (var sw = new StreamWriter(temp_file))
        //    {
        //        string line;
        //        while ((line = sr.ReadLine()) != null)
        //        {
        //            Secretary secretary = ConvertCSVFormatToSecretary(line);
        //            if (secretary.Id != id)
        //            {
        //                retVal = true;
        //                sw.WriteLine(line);
        //            }
        //        }
        //    }

        //    File.Delete(secretary_file);
        //    File.Move(temp_file, secretary_file);

        //    return retVal;
        //}




        public IEnumerable<Secretary> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToSecretary)
             .ToList();
        }

        private Secretary ConvertCSVFormatToSecretary(string secretaryCSVFormat)
        {
            Secretary secretary = new Secretary();
            string[] tokens = secretaryCSVFormat.Split(_delimeter.ToCharArray());
            // 1; DUNJICA; sssss; 02 - May - 22; s; sss; sss @gmail.com
            //4;ARSENIJE;Lalic;22-May-22;arsa;Svetozara Miletica 4;arsa@gmail.com
            uint Id = uint.Parse(tokens[0]);
            string Username = tokens[1];
            string Password = tokens[2];      

            return new Secretary(
                Id,              
                Username,
                Password
            );

        }


        private string ConvertSecretaryToCSVFormat(Secretary secretary)
        {
            return string.Join(_delimeter,
                secretary.Id,               
                secretary.Username,
                secretary.Password
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
