using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Equipment
    {
        public uint Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public Equipment()
        {

        }

        public Equipment(uint id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }

        public Equipment(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }
}
