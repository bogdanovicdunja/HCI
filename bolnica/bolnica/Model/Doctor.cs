using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Doctor
    {
        public uint Id { get; set; }
        public string Name { get; set; }

        public Doctor(uint id, string name)
        {
            Id = id;
            Name = name;
        }

        public Doctor()
        {

        }
    }
}
