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
    public class RoomRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _roomrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public RoomRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _roomrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Room> rooms)
        {
            return rooms.Count() == 0 ? 0 : rooms.Max(room => room.Id);
        }


        public Room AddRoom(Room room)
        {
            room.Id = ++_roomrMaxId;
            AppendLineToFile(_path, ConvertRoomToCSVFormat(room));
            return room;
        }

        public Room GetRoom(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(room => room.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Room FindRoomByUsername(string username)
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

        public Room UpdateRoom(Room room)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\room.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertRoomToCSVFormat(room);
                    Room tempApp = ConvertCSVFormatToRoom(line);
                    if (room.Id != tempApp.Id)
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



            return room;
        }




        public Boolean RemoveRoom(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Room> rooms = GetAll();

            rooms = rooms.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string room_file = _projectPath + "\\Resources\\room.txt";

            using (var sr = new StreamReader(room_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Room room = ConvertCSVFormatToRoom(line);
                    if (room.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(room_file);
            File.Move(temp_file, room_file);

            return retVal;
        }




        public IEnumerable<Room> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToRoom)
             .ToList();
        }

        private Room ConvertCSVFormatToRoom(string roomCSVFormat)
        {
            Room room = new Room();
            string[] tokens = roomCSVFormat.Split(_delimeter.ToCharArray());

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

            return new Room(
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


        private string ConvertRoomToCSVFormat(Room room)
        {
            return string.Join(_delimeter,
                room.Id,
                //room.Username,
                //room.Password,
                room.Name
                //room.Surname,
                //room.Username,
                //room.Adress,
                //room.Email
                //room.Gender,
                //room.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
