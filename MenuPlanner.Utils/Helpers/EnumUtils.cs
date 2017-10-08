using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Utils.Helpers
{
    public static class EnumUtils
    {
        public static IEnumerable<T> ListFromMask<T>(Enum val)
        {
            return Enum.GetValues(typeof(T))
                       .Cast<Enum>()
                       .Where(m => val.HasFlag(m))
                       .Cast<T>();
        }

        public static TimeSlot TimeSlotMaskFromList(IEnumerable<TimeSlot> list)
        {
            TimeSlot res = default(TimeSlot);

            foreach (var val in list)
            {
                res |= val;
            }

            return res;
        }

    }
}
