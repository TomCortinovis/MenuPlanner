using MenuPlanner.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Business.BusinessObjects;

namespace MenuPlanner.Business.Services.Implementations
{
    public class SessionService : ISessionService
    {
        private Profile _currentProfile;

        public Profile CurrentProfile
        {
            get { return _currentProfile; }
            set
            {
                if (value != _currentProfile)
                {
                    _currentProfile = value;
                    ProfileChanged?.Invoke(this, value);
                }
            }
        }

        public event EventHandler<Profile> ProfileChanged;
    }
}
