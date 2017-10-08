using MenuPlanner.Business.BusinessObjects;

namespace MenuPlanner.Common.Popups.Models
{
    public class PlanningEditionPopupParameters : PopupParameters
    {
        public MealSchedule Schedule { get; set; }

        public Profile Profile { get; set; }
    }
}
