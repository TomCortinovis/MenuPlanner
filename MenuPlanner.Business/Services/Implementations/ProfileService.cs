using MenuPlanner.Business.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Utils.Transverse;
using MenuPlanner.Business.Repositories;

namespace MenuPlanner.Business.Services.Implementations
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileRepository _profileRepository;

        public ProfileService(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public IEnumerable<Profile> GetCreatedProfiles()
        {
            return _profileRepository.GetAllProfiles();
        }

        public void CreateProfile(Profile toCreate)
        {
            _profileRepository.CreateProfile(toCreate);
        }

        public void UpdateProfile(Profile toUpdate, string oldName)
        {
            _profileRepository.UpdateProfile(toUpdate, oldName);
        }

        public void DeleteProfile(Profile toDelete)
        {
            _profileRepository.DeleteProfile(toDelete);
        }

    }
}
