using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Surgery
    {
        public uint Id { get; set; }
        public DateTime Start { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string RoomName { get; set; }

        public Surgery()
        {

        }

        public Surgery(uint id, DateTime start, string patientName, string doctorName, string roomName)
        {
            Id = id;
            Start = start;
            PatientName = patientName;
            DoctorName = doctorName;
            RoomName = roomName;
        }

        public Surgery(DateTime start, string patientName, string doctorName, string roomName)
        {
            Start = start;
            PatientName = patientName;
            DoctorName = doctorName;
            RoomName = roomName;
        }

        public Surgery(uint id)
        {
            Id = id;
        }
    }
}
