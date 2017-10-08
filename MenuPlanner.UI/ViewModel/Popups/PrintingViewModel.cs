using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MenuPlanner.Common.Popups.Models;
using MenuPlanner.UI.Models;
namespace MenuPlanner.UI.ViewModel.Popups
{
    public class PrintingViewModel : Popup
    {
        private MealScheduleModel _schedule;
        public MealScheduleModel Schedule
        {
            get { return _schedule; }
            set { Set(ref _schedule, value); }
        }

        private List<string> _titles;
        public List<string> Titles
        {
            get { return _titles; }
            set { Set(ref _titles, value); }
        }

        public override void Show(PopupParameters parameters)
        {
            base.Show(parameters);

            Schedule = Mapper.Map<MealScheduleModel>((Parameters as PlanningEditionPopupParameters).Schedule);

            Titles = Schedule.Meals.Select(m => m.Title).ToList();
        }
    }
}