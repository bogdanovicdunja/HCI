using bolnica.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bolnica.ViewModel
{
    public class MeetingsVM : ViewModelBase
    {
        private readonly Meeting _meeting;


        public uint Id => _meeting.Id;
        public DateTime Date => _meeting.Date;
        public string RoomName => _meeting.RoomName;
        public string Topic => _meeting.Topic;




        public MeetingsVM(Meeting meeting)
        {
            _meeting = meeting;
        }
    }
}
