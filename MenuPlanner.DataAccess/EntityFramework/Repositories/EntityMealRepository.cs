using MenuPlanner.Business.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.Business.BusinessObjects;
using AutoMapper;
using MenuPlanner.DataAccess.EntityFramework.Domain;
using MenuPlanner.Utils.Transverse;

namespace MenuPlanner.DataAccess.EntityFramework.Repositories
{
    public class EntityMealRepository : IMealRepository
    {
        public void AddMeal(Meal meal, Business.BusinessObjects.Profile profile)
        {
            var mealDto = Mapper.Map<MealDto>(meal);

            using (var context = new MenuPlannerContext())
            {
                mealDto.Profile = context.Profiles.First(p => p.Name == profile.Name);

                context.Meals.Add(mealDto);
                context.SaveChanges();
            }
        }

        public void UpdateMeal(Meal meal, Business.BusinessObjects.Profile profile)
        {
            using (var context = new MenuPlannerContext())
            {
                var mealDto = context.Meals.First(m => m.Day == meal.Day && m.Time == meal.Time && m.Profile.Name == profile.Name);

                mealDto.Title = meal.Title;

                context.SaveChanges();
            }
        }

        public IEnumerable<Meal> GetAllMealsForProfile(Business.BusinessObjects.Profile profile)
        {
            var profileDto = Mapper.Map<Business.BusinessObjects.Profile, ProfileDto>(profile);

            using (var context = new MenuPlannerContext())
            {
                return Mapper.Map<List<Meal>>(context.Meals.Where(m => m.Profile.Name == profileDto.Name));
            }

        }

        public bool DoesMealAlreadyExist(DateTime day, TimeSlot time, Business.BusinessObjects.Profile profile)
        {
            using (var context = new MenuPlannerContext())
            {
                return context.Meals.Any(m => m.Day == day && m.Time == time && m.Profile.Name == profile.Name);
            }
        }
    }
}
