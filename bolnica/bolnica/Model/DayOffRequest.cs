using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class DayOffRequest
    {
        public uint Id { get; set; }
        public string DoctorName { get; set; }
       // public string DoctorSurname { get; set; }
        public string Specialization { get; set; }
        public string Start { get; set; }
        public string End { get; set; }

        public DayOffRequest()
        {

        }

        public DayOffRequest(uint id, string doctorName, string specialization, string start, string end)
        {
            Id = id;
            DoctorName = doctorName;
            Specialization = specialization;
            Start = start;
            End = end;
        }

        public DayOffRequest(string doctorName, string specialization, string start, string end)
        {
            DoctorName = doctorName;
            Specialization = specialization;
            Start = start;
            End = end;
        }
    }
}
