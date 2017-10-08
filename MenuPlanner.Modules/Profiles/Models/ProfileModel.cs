using System.Collections.Generic;
using GalaSoft.MvvmLight;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.Modules.Profiles.Models
{
    public class ProfileModel : ObservableObject
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { Set(ref _name, value); }
        }

        private IEnumerable<TimeSlot> _selectedTimes;
        public IEnumerable<TimeSlot> SelectedTimes
        {
            get { return _selectedTimes; }
            set { Set(ref _selectedTimes, value); }
        }
    }
}