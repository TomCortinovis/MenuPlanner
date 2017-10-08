using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Common.Popups.Managers;
using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.Modules.Profiles.ViewModels
{
    public class ProfileViewModel : ViewModelBase, IModule
    {
        private readonly IProfileService _profileService;
        private readonly IPopupManager _popupManager;

        public string Name => "Profile";

        public int Order => 2;

        private ObservableCollection<Profile> _profiles;
        public ObservableCollection<Profile> Profiles
        {
            get { return _profiles; }
            set { Set(ref _profiles, value); }
        }

        private Profile _selectedProfile;
        public Profile SelectedProfile
        {
            get { return _selectedProfile; }
            set
            {
                Set(ref _selectedProfile, value);
                ((RelayCommand)EditProfileCommand).RaiseCanExecuteChanged();
                ((RelayCommand)DeleteProfileCommand).RaiseCanExecuteChanged();
            }
        }

        public ICommand DeleteProfileCommand { get; }

        public ICommand EditProfileCommand { get; }

        public ICommand CreateProfileCommand { get; }

        public ProfileViewModel(IProfileService profileService, IPopupManager popupManager)
        {
            _profileService = profileService;
            _popupManager = popupManager;
            Profiles = new ObservableCollection<Profile>(_profileService.GetCreatedProfiles());

            DeleteProfileCommand = new RelayCommand(DeleteProfile, CanModifyProfile);
            EditProfileCommand = new RelayCommand(EditProfile, CanModifyProfile);
            CreateProfileCommand = new RelayCommand(CreateProfile);
        }

        private void DeleteProfile()
        {
            _profileService.DeleteProfile(SelectedProfile);
            RefreshProfiles();
        }

        private void EditProfile()
        {
            _popupManager.ShowPopup<ProfileEditionViewModel>(new ProfileEditionPopupParameters
            {
                Profile = SelectedProfile
            }).OnClose(ProfilePopupClosed);
        }

        private void CreateProfile()
        {
            _popupManager.ShowPopup<ProfileEditionViewModel>().OnClose(ProfilePopupClosed);
        }

        private bool CanModifyProfile()
        {
            return SelectedProfile != null;
        }

        private void ProfilePopupClosed(PopupClosedEventArgs e)
        {
            if (!e.Success) return;

            RefreshProfiles();
        }

        private void RefreshProfiles()
        {
            Profiles = new ObservableCollection<Profile>(_profileService.GetCreatedProfiles());
        }
    }
}