using bolnica.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bolnica.ViewModel
{
    public class MeetingsListingVM : ViewModelBase
    {

        private readonly ObservableCollection<MeetingsVM> _meetings;
        public IEnumerable<MeetingsVM> Meetings => _meetings;

        public ICommand DeleteMeetingCommand { get; }

        public ICommand AddMeetingCommand { get; }


        public MeetingsListingVM()
        {
            _meetings = new ObservableCollection<MeetingsVM>();

            _meetings.Add(new MeetingsVM(new Meeting(DateTime.Now, "707", "godisnji")));
            _meetings.Add(new MeetingsVM(new Meeting(DateTime.Now, "808", "seminar")));
            _meetings.Add(new MeetingsVM(new Meeting(DateTime.Now, "909", "povisice")));
            _meetings.Add(new MeetingsVM(new Meeting(DateTime.Now, "205", "specijalizacije")));
        }
    }
}
