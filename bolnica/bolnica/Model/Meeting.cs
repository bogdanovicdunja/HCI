using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Meeting
    {

        public uint Id { get; set; }
        public DateTime Date { get; set; }
        public string RoomName { get; set; }
        public string Topic { get; set; }

        public Meeting()
        {

        }

        public Meeting(uint id, DateTime date, string roomName, string topic)
        {
            Id = id;
            Date = date;
            RoomName = roomName;
            Topic = topic;
        }

        public Meeting(DateTime date, string roomName, string topic)
        {
            Date = date;
            RoomName = roomName;
            Topic = topic;
        }

    }
}
