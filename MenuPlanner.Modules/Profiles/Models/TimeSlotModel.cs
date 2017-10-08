using System.CodeDom;
using GalaSoft.MvvmLight;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.Modules.Profiles.Models
{
    public class TimeSlotModel : ObservableObject
    {
        private TimeSlot _timeSlot;
        public TimeSlot TimeSlot
        {
            get { return _timeSlot; }
            set { Set(ref _timeSlot, value); }
        }

        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { Set(ref _isSelected, value); }
        }
    }
}