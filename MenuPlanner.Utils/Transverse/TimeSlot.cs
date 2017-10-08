using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Utils.Transverse
{
    [Flags]
    public enum TimeSlot : int
    {
        Breakfast = 1,
        Lunch = 2,
        Snack = 4,
        Diner = 8
    }

    public static class TimeSlotExtensions
    {
        public static string ToText(this TimeSlot time)
        {
            switch (time)
            {
                case TimeSlot.Breakfast:
                    return "Matin";
                case TimeSlot.Lunch:
                    return "Midi";
                case TimeSlot.Snack:
                    return "Gouter";
                case TimeSlot.Diner:
                    return "Diner";
                default:
                    return "Inconnu";
            }
        }
    }
}
