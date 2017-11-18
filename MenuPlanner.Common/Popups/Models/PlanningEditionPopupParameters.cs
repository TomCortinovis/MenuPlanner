using MenuPlanner.Business.BusinessObjects;
using System.Collections.Generic;

namespace MenuPlanner.Common.Popups.Models
{
    public class PlanningEditionPopupParameters : PopupParameters
    {
        public MealSchedule Schedule { get; set; }

        public Profile Profile { get; set; }
    }
}
