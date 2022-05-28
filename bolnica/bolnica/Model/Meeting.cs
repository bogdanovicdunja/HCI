using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    internal class Meeting
    {

        public uint Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Room { get; set; }
        public string Topic { get; set; }

        public Meeting()
        {

        }

        public Meeting(uint id, string date, string time, string room, string topic)
        {
            Id = id;
            Date = date;
            Time = time;
            Room = room;
            Topic = topic;
        }

        public Meeting(string date, string time, string room, string topic)
        {
            Date = date;
            Time = time;
            Room = room;
            Topic = topic;
        }
    }
}
