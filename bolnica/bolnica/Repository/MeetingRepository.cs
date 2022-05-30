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
    public class MeetingRepository
    {
        private const string NOT_FOUND_ERROR = "Account with {0}:{1} can not be found!";
        private readonly string _path;
        private readonly string _delimeter;
        private readonly string _dateTimeFormat;
        private uint _meetingrMaxId;
        private static string _projectPath = System.Reflection.Assembly.GetExecutingAssembly().Location
        .Split(new string[] { "bin" }, StringSplitOptions.None)[0];
        private FileStream temp;

        public MeetingRepository(string path, string delimeter)
        {
            _path = path;
            _delimeter = delimeter;
            _meetingrMaxId = GetMaxId(GetAll());
        }

        private uint GetMaxId(IEnumerable<Meeting> meetings)
        {
            return meetings.Count() == 0 ? 0 : meetings.Max(meeting => meeting.Id);
        }


        public Meeting AddMeeting(Meeting meeting)
        {
            meeting.Id = ++_meetingrMaxId;
            AppendLineToFile(_path, ConvertMeetingToCSVFormat(meeting));
            return meeting;
        }

        public Meeting GetMeeting(uint id)
        {
            try
            {

                return GetAll().SingleOrDefault(meeting => meeting.Id == id);

            }
            catch (ArgumentException)
            {

                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));

            }
        }

        //public Meeting FindMeetingByUsername(string username)
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

        public Meeting UpdateMeeting(Meeting meeting)
        {
            string temp_file = _projectPath + "\\Resources\\tempPAT.txt";
            string _file = _projectPath + "\\Resources\\meetings.txt";


            using (var sr = new StreamReader(_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string lineToWrite = ConvertMeetingToCSVFormat(meeting);
                    Meeting tempApp = ConvertCSVFormatToMeeting(line);
                    if (meeting.Id != tempApp.Id)
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



            return meeting;
        }




        public Boolean RemoveMeeting(uint id)
        {
            Boolean retVal = false;
            IEnumerable<Meeting> meetings = GetAll();

            meetings = meetings.Where(a => a.Id != id).ToList();

            string temp_file = _projectPath + "\\Resources\\tempPat.txt";
            string meeting_file = _projectPath + "\\Resources\\meetings.txt";

            using (var sr = new StreamReader(meeting_file))
            using (var sw = new StreamWriter(temp_file))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Meeting meeting = ConvertCSVFormatToMeeting(line);
                    if (meeting.Id != id)
                    {
                        retVal = true;
                        sw.WriteLine(line);
                    }
                }
            }

            File.Delete(meeting_file);
            File.Move(temp_file, meeting_file);

            return retVal;
        }




        public IEnumerable<Meeting> GetAll()
        {
            return File.ReadAllLines(_path)
             .Select(ConvertCSVFormatToMeeting)
             .ToList();
        }

        private Meeting ConvertCSVFormatToMeeting(string meetingCSVFormat)
        {
            Meeting meeting = new Meeting();
            string[] tokens = meetingCSVFormat.Split(_delimeter.ToCharArray());

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
            //string PatientName = tokens[2];
            //string DoctorName = tokens[3];
            string RoomName = tokens[2];
            string Topic = tokens[3];

            return new Meeting(
                Id,
                DateTime.Parse(tokens[1]),
                RoomName,
                Topic
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


        private string ConvertMeetingToCSVFormat(Meeting meeting)
        {
            return string.Join(_delimeter,
                meeting.Id,
                meeting.Date,
                //meeting.Username,
                //meeting.Password,
                meeting.RoomName,
                meeting.Topic
                //meeting.Surname,
                //meeting.Username,
                //meeting.Adress,
                //meeting.Email
                //meeting.Gender,
                //meeting.DateOfBirth
                );

        }

        private void AppendLineToFile(string path, string line)
        {
            File.AppendAllText(path, line + Environment.NewLine);
        }
    }
}
