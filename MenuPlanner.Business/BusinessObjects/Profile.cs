using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.BusinessObjects
{
    public class Profile
    {
        public string Name { get; set; }

        public IEnumerable<TimeSlot> SelectedTimes { get; set; }

        public IEnumerable<Meal> Meals { get; set; }
    }
}
