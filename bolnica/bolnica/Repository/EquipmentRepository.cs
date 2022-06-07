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
    public class EquipmentRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _equipmentrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public EquipmentRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _equipmentrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Equipment> equipments)
        {
            return equipments.Count() == 0 ? 0 : equipments.Max(equipment => equipment.Id);
        }


        public Equipment AddEquipment(Equipment equipment)
        {
            equipment.Id = ++_equipmentrMaxId;
            AppendLineToFile(_path, ConvertEquipmentToCSVFormat(equipment));
            return equipment;
        }

        public Equipment GetEquipment(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(equipment => equipment.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }


        public Equipment UpdateEquipment(Equipment equipment)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\equipment.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertEquipmentToCSVFormat(equipment);
                    Equipment tempApp = ConvertCSVFormatToEquipment(line);
                    if (equipment.Id != tempApp.Id)
                    {
                        sw.WriteLine(line);
                    }
                    else
                    {
                        sw.WriteLine(lineToWrite);
                    }
            
                }
            }
            File.Delete(_file);
            File.Move(temp_file, _file);



            return equipment;
        }




        public Boolean RemoveEquipment(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Equipment> equipments = GetAll();

            equipments = equipments.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string equipment_file = _projectPath + "\\Resources\\equipment.txt";

            using (var sr = new StreamReader(equipment_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Equipment equipment = ConvertCSVFormatToEquipment(line);
                    if (equipment.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(equipment_file);
            File.Move(temp_file, equipment_file);

            return retVal;
        }




        public IEnumerable<Equipment> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToEquipment)
             .ToList();
        }

        private Equipment ConvertCSVFormatToEquipment(string equipmentCSVFormat)
        {
            Equipment equipment = new Equipment();
            string[] tokens = equipmentCSVFormat.Split(_delimeter.ToCharArray());

            uint Id = uint.Parse(tokens[0]);
            string Name = tokens[1];
            int Quantity = int.Parse(tokens[2]);
            

            return new Equipment(
                Id,
                Name,
                Quantity
            );

        }


        private string ConvertEquipmentToCSVFormat(Equipment equipment)
        {
            return string.Join(_delimeter,
                equipment.Id,
                equipment.Name,
                equipment.Quantity            
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
