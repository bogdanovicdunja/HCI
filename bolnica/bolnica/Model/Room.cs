using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public RoomType Type { get; set; }

        public Room()
        {

        }

        public Room(int id)
        {
            Id = id;
        }

        public Room(int id, string name, RoomType type) : this(id)
        {
            Name = name;
            Type = type;
        }

        public Room(string name, RoomType type)
        {
            Name = name;
            Type = type;
        }
    }
}
