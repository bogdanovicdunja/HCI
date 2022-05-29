using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.Model
{
    public class Appointment
    {
        public uint Id { get; set; }
        public DateTime Start { get; set; }
        //public Patient Patient { get; set; }
        public string PatientName { get; set; }
        public string DoctorName { get; set; }
        public string RoomName{ get; set; }

        public Appointment(uint id, DateTime start, string patientName, string doctorName, string roomName)
        {
            Id = id;
            Start = start;
            PatientName = patientName;
            DoctorName = doctorName;
            RoomName = roomName;
        }

        public Appointment(DateTime start, string patientName, string doctorName, string roomName)
        {
            Start = start;
            PatientName = patientName;
            DoctorName = doctorName;
            RoomName = roomName;
        }

        public Appointment(uint id)
        {
            Id = id;
        }

        public Appointment()
        {

        }
    }
}
