using GalaSoft.MvvmLight;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Services.Contracts;

namespace MenuPlanner.Common
{
    public class BaseViewModel : ViewModelBase
    {
        protected ISessionService Session { get; }

        private Profile _currentProfile;
        public Profile CurrentProfile
        {
            get { return _currentProfile; }
            set { Set(ref _currentProfile, value); }
        }

        public BaseViewModel(ISessionService session)
        {
            Session = session;
            Session.ProfileChanged += SessionService_ProfileChanged;
        }

        /// <summary>
        /// To be overriden by derived classes to adjust to profile change
        /// </summary>
        /// <param name="profile"></param>
        protected virtual void ProfileChangedOverride()
        {

        }

        private void SessionService_ProfileChanged(object sender, Profile e)
        {
            CurrentProfile = e;
            ProfileChangedOverride();
        }

    }
}
