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
    public class AllergenRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _allergenrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public AllergenRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _allergenrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Allergen> allergens)
        {
            return allergens.Count() == 0 ? 0 : allergens.Max(allergen => allergen.Id);
        }


        public Allergen AddAllergen(Allergen allergen)
        {
            allergen.Id = ++_allergenrMaxId;
            AppendLineToFile(_path, ConvertAllergenToCSVFormat(allergen));
            return allergen;
        }

        public Allergen GetAllergen(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(allergen => allergen.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Allergen FindAllergenByUsername(string username)
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

        public Allergen UpdateAllergen(Allergen allergen)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\allergen.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertAllergenToCSVFormat(allergen);
                    Allergen tempApp = ConvertCSVFormatToAllergen(line);
                    if (allergen.Id != tempApp.Id)
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



            return allergen;
        }




        public Boolean RemoveAllergen(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Allergen> allergens = GetAll();

            allergens = allergens.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string allergen_file = _projectPath + "\\Resources\\allergen.txt";

            using (var sr = new StreamReader(allergen_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Allergen allergen = ConvertCSVFormatToAllergen(line);
                    if (allergen.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(allergen_file);
            File.Move(temp_file, allergen_file);

            return retVal;
        }




        public IEnumerable<Allergen> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToAllergen)
             .ToList();
        }

        private Allergen ConvertCSVFormatToAllergen(string allergenCSVFormat)
        {
            Allergen allergen = new Allergen();
            string[] tokens = allergenCSVFormat.Split(_delimeter.ToCharArray());

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

            return new Allergen(
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


        private string ConvertAllergenToCSVFormat(Allergen allergen)
        {
            return string.Join(_delimeter,
                allergen.Id,
                //allergen.Username,
                //allergen.Password,
                allergen.Name
                //allergen.Surname,
                //allergen.Username,
                //allergen.Adress,
                //allergen.Email
                //allergen.Gender,
                //allergen.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
