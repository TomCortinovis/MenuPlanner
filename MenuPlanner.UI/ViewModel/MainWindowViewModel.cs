using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Services.Contracts;
using MenuPlanner.Modules;
using MenuPlanner.UI.Managers;
using MenuPlanner.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using MenuPlanner.Common.Popups.Managers;
using MenuPlanner.Common.Popups.Models;

namespace MenuPlanner.UI.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ISessionService _sessionService;

        private IPage _mainPage;
        public IPage MainPage
        {
            get { return _mainPage; }
            set { Set(ref _mainPage, value); }
        }

        private IModule _selectedModule;
        public IModule SelectedModule
        {
            get { return _selectedModule; }
            set { Set(ref _selectedModule, value); }
        }

        private List<Profile> _profiles;
        public List<Profile> Profiles
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
                _sessionService.CurrentProfile = _selectedProfile;
            }
        }

        private Popup _currentPopup;
        public Popup CurrentPopup
        {
            get { return _currentPopup; }
            set { Set(ref _currentPopup, value); }
        }

        public List<IModule> Modules { get; }

        public List<IPage> Pages { get; }

        public ICommand ClosePopupCommand { get; }

        public MainWindowViewModel(IEnumerable<IPage> pages, IEnumerable<IModule> modules, IProfileService profileService, ISessionService sessionService, IPopupManager popupManager)
        {
            _sessionService = sessionService;

            Pages = pages.OrderBy(p => p.Order).ToList();
            MainPage = Pages.FirstOrDefault();

            Modules = modules.OrderBy(m => m.Order).ToList();
            SelectedModule = Modules.FirstOrDefault();

            Profiles = profileService.GetCreatedProfiles().ToList();
            SelectedProfile = Profiles.FirstOrDefault();

            popupManager.PopupChanged += PopupManager_PopupChanged;

            ClosePopupCommand = new RelayCommand(() => CurrentPopup.Close(false));
        }

        private void PopupManager_PopupChanged(object sender, Popup e)
        {
            CurrentPopup = e;
        }
    }
}
