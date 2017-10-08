using MenuPlanner.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuPlanner.Business.BusinessObjects;
using AutoMapper;
using MenuPlanner.DataAccess.EntityFramework.Domain;
using MenuPlanner.Utils.Helpers;
using Profile = MenuPlanner.Business.BusinessObjects.Profile;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.DataAccess.EntityFramework.Repositories
{
    public class EntityProfileRepository : IProfileRepository
    {
        public void CreateProfile(Profile toCreate)
        {
            var dto = Mapper.Map<ProfileDto>(toCreate);

            using (var context = new MenuPlannerContext())
            {
                context.Profiles.Add(dto);
                context.SaveChanges();
            }
        }

        public void UpdateProfile(Profile toUpdate, string oldName)
        {
            using (var context = new MenuPlannerContext())
            {
                var profile = context.Profiles.First(p => p.Name == oldName);

                profile.Name = toUpdate.Name;
                profile.SelectedTimes = (int)EnumUtils.TimeSlotMaskFromList(toUpdate.SelectedTimes);

                context.SaveChanges();
            }
        }

        public IEnumerable<Profile> GetAllProfiles()
        {
            using (var context = new MenuPlannerContext())
            {
                return Mapper.Map<List<Profile>>(context.Profiles.ToList());
            }
        }

        public void DeleteProfile(Profile toDelete)
        {
            using (var context = new MenuPlannerContext())
            {
                var profile = context.Profiles.First(p => p.Name == toDelete.Name);

                context.Profiles.Remove(profile);
                context.SaveChanges();
            }
        }
    }
}
