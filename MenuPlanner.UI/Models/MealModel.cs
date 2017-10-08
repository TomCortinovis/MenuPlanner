using GalaSoft.MvvmLight;
using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.UI.Models
{
    public class MealModel : ObservableObject
    {
        private DateTime _day;
        public DateTime Day
        {
            get { return _day; }
            set { Set(ref _day, value); }
        }

        private TimeSlot _time;
        public TimeSlot Time
        {
            get { return _time; }
            set { Set(ref _time, value); }
        }

        private string _title;
        public string Title
        {
            get { return _title; }
            set
            {
                if (Set(ref _title, value))
                {
                    IsModified = true;
                }
            }
        }

        private bool _isModified;
        public bool IsModified
        {
            get { return _isModified; }
            set { Set(ref _isModified, value); }
        }
    }
}
