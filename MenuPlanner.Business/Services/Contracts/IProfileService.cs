using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Services.Contracts
{
    public interface IProfileService
    {
        IEnumerable<Profile> GetCreatedProfiles();

        void CreateProfile(Profile toCreate);

        void UpdateProfile(Profile toUpdate, string oldName);

        void DeleteProfile(Profile toDelete);
    }
}
