using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;
using AutoMapper;
using GalaSoft.MvvmLight.CommandWpf;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Common.Popups.Models;
using MenuPlanner.Modules.Profiles.Models;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.Modules.Profiles.ViewModels
{
    public class ProfileEditionViewModel : Popup
    {
        private readonly IProfileService _profileService;

        private string _oldName;
        private bool _isEditMode;

        private ObservableCollection<TimeSlotModel> _allTimeSlots;
        public ObservableCollection<TimeSlotModel> AllTimeSlots
        {
            get { return _allTimeSlots; }
            set { Set(ref _allTimeSlots, value); }
        }

        private ProfileModel _profile;
        public ProfileModel Profile
        {
            get { return _profile; }
            set { Set(ref _profile, value); }
        }


        public ICommand SaveOrUpdateCommand { get; }

        public ProfileEditionViewModel(IProfileService profileService)
        {
            _profileService = profileService;

            SaveOrUpdateCommand = new RelayCommand(SaveOrUpdate);

            Profile = new ProfileModel();
            AllTimeSlots = new ObservableCollection<TimeSlotModel>();

            foreach (var slot in ((TimeSlot[])Enum.GetValues(typeof(TimeSlot))))
            {
                AllTimeSlots.Add(new TimeSlotModel {TimeSlot = slot});
            }
        }

        public override void Show(PopupParameters parameters)
        {
            base.Show(parameters);

            var profile = (Parameters as ProfileEditionPopupParameters)?.Profile;

            _isEditMode = true;

            if (profile == null)
            {
                _isEditMode = false;
            }
            else
            {
                Profile = Mapper.Map<ProfileModel>(profile);

                _oldName = Profile.Name;

                foreach (var selectedTime in Profile.SelectedTimes)
                {
                    AllTimeSlots.First(t => t.TimeSlot == selectedTime).IsSelected = true;
                }
            }
        }

        private void SaveOrUpdate()
        {
            // TODO Check if name is unique

            Profile.SelectedTimes = AllTimeSlots.Where(ts => ts.IsSelected).Select(ts => ts.TimeSlot);

            if (!_isEditMode)
            {
                _profileService.CreateProfile(Mapper.Map<Business.BusinessObjects.Profile>(Profile));
            }
            else
            {
                _profileService.UpdateProfile(Mapper.Map<Business.BusinessObjects.Profile>(Profile), _oldName);
            }

            Close(true);
        }
    }
}