﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.UI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Common.Popups.Managers;
using MenuPlanner.Common.Popups.Models;
using MenuPlanner.UI.Managers;
using MenuPlanner.UI.ViewModel.Popups;
using MenuPlanner.Utils.Transverse;
using System.Windows.Media.Imaging;
using System.IO;
using MenuPlanner.Services;
using MenuPlanner.Common;

namespace MenuPlanner.UI.ViewModel
{
    public class PlanningViewModel : BaseViewModel, IPage
    {
        private readonly IMealService _mealService;
        private readonly IPopupManager _popupManager;
        private readonly IFileService _fileService;
        private List<MealSchedule> _fullSchedule;

        private List<MealSchedule> _schedule;
        public List<MealSchedule> Schedule
        {
            get { return _schedule; }
            set { Set(ref _schedule, value); }
        }

        private PlanningMode _mode;
        public PlanningMode Mode
        {
            get { return _mode; }
            set
            {
                Set(ref _mode, value);
                RaisePropertyChanged(() => Paginator);
            }
        }

        private IPaginationManager _paginator;
        public IPaginationManager Paginator
        {
            get { return _paginator; }
            set { Set(ref _paginator, value); }
        }

        public event EventHandler ScreenshotRequested;

        public ICommand ChangePlanningModeCommand { get; }

        public ICommand NextPageCommand { get; }

        public ICommand PreviousPageCommand { get; }

        public ICommand PlanningSelectCommand { get; }

        public ICommand PrintCommand { get; }

        public string Name => "Planning";

        public int Order => 1;

        public PlanningViewModel(IMealService mealService, ISessionService sessionService, IPaginationManager paginationManager, IPopupManager popupManager, IFileService fileService) : base(sessionService)
        {
            _mealService = mealService;
            _popupManager = popupManager;
            _fileService = fileService;
            Paginator = paginationManager;

            ChangePlanningModeCommand = new RelayCommand<PlanningMode>(OnChangePlanningMode);
            NextPageCommand = new RelayCommand(OnNextPageRequested);
            PreviousPageCommand = new RelayCommand(OnPreviousPageRequested);
            PlanningSelectCommand = new RelayCommand<MealSchedule>(OnPlanningSelected);
            PrintCommand = new RelayCommand(AskForScreenshot);
        }

        public void SaveScreenshot(BitmapEncoder encoder)
        {
            string path = _fileService.SaveScreenshot(encoder);

            _popupManager.ShowMessage($"La capture du planning a bien été enregistrée au chemin suivant : {path}");
        }

        private void OnPlanningSelected(MealSchedule meal)
        {
            _popupManager.ShowPopup<PlanningEditionViewModel>(new PlanningEditionPopupParameters
                                                    {
                                                        Schedule = meal,
                                                        Profile = CurrentProfile
                                                    }).OnClose(PlanningPopupClosed);

        }

        private void PlanningPopupClosed(PopupClosedEventArgs closedArgs)
        {
            if (!closedArgs.Success) return;

            _fullSchedule = _mealService.GetMealScheduleForProfile(CurrentProfile).ToList();
            LoadSchedule();
        }


        private void OnNextPageRequested()
        {
            Paginator.GoNext();
            LoadSchedule();
        }

        private void OnPreviousPageRequested()
        {
            Paginator.GoBack();
            LoadSchedule();
        }

        private void OnChangePlanningMode(PlanningMode newMode)
        {
            Paginator.CurrentPage = 1;
            switch (newMode)
            {
                case PlanningMode.Monthly:
                    Paginator.PageSize = 28;
                    break;
                case PlanningMode.Weekly:
                    Paginator.PageSize = 7;
                    break;
            }

            Mode = newMode;

            LoadSchedule();
        }

        protected override void ProfileChangedOverride()
        {
            _fullSchedule = _mealService.GetMealScheduleForProfile(CurrentProfile).ToList();

            Paginator.TotalNumberOfElements = _fullSchedule.Count;

            Schedule = _fullSchedule;
            OnChangePlanningMode(PlanningMode.Monthly);
        }

        private void LoadSchedule()
        {
            Schedule = _fullSchedule.Skip((Paginator.CurrentPage - 1) * Paginator.PageSize).Take(Paginator.PageSize).ToList();
        }

        private void AskForScreenshot()
        {
            ScreenshotRequested(this, EventArgs.Empty);
        }
    }
}
