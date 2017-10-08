using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Repositories
{
    public interface IProfileRepository
    {
        void CreateProfile(Profile toCreate);

        void UpdateProfile(Profile toUpdate, string oldName);

        IEnumerable<Profile> GetAllProfiles();

        void DeleteProfile(Profile toDelete);
    }
}
