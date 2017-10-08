using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.BusinessObjects
{
    public class Meal
    {
        public DateTime Day { get; set; }

        public TimeSlot Time { get; set; }

        public string Title { get; set; }

        public Meal(DateTime day, TimeSlot time)
        {
            Day = day;
            Time = time;
        }

        public Meal(DateTime day, TimeSlot time, string title) : this(day, time)
        {
            Title = title;
        }

    }
}
