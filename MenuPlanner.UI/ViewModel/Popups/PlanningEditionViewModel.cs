using AutoMapper;
using GalaSoft.MvvmLight.Command;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.UI.Managers;
using MenuPlanner.UI.Models;
using System.Collections.Generic;
using System.Windows.Input;
using System;
using MenuPlanner.Business.Services.Contracts;
using System.Linq;
using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.UI.ViewModel.Popups
{
    public class PlanningEditionViewModel : Popup
    {
        private readonly IMealService _mealService;
        private readonly ISessionService _sessionService;

        private MealScheduleModel _schedule;
        public MealScheduleModel Schedule
        {
            get { return _schedule; }
            set { Set(ref _schedule, value); }
        }

        public ICommand SaveOrUpdateCommand { get; }

        public PlanningEditionViewModel(IMealService mealService, ISessionService sessionService)
        {
            _mealService = mealService;
            _sessionService = sessionService;

            SaveOrUpdateCommand = new RelayCommand(SaveOrUpdateMeals);
        }

        public override void Show(PopupParameters parameters)
        {
            base.Show(parameters);

            Schedule = Mapper.Map<MealScheduleModel>((Parameters as PlanningEditionPopupParameters).Schedule);
        }

        private void SaveOrUpdateMeals()
        {
            var changedMeals = Mapper.Map<List<Meal>>(Schedule.Meals.Where(m => m.IsModified));

            _mealService.AddOrUpdateMeals(changedMeals, _sessionService.CurrentProfile);

            Close(true);
        }
    }
}
