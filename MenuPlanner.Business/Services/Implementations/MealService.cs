using System;
using System.Collections.Generic;
using System.Linq;
using MenuPlanner.Business.BusinessObjects;
using MenuPlanner.Business.Repositories;
using MenuPlanner.Business.Services.Contracts;

namespace MenuPlanner.Business.Services.Implementations
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {
            _mealRepository = mealRepository;
        }

        public void AddOrUpdateMeals(IEnumerable<Meal> changedMeals, Profile profile)
        {
            foreach (var meal in changedMeals)
            {
                if (_mealRepository.DoesMealAlreadyExist(meal.Day, meal.Time, profile))
                {
                    _mealRepository.UpdateMeal(meal, profile);
                }
                else
                {
                    _mealRepository.AddMeal(meal, profile);
                }
            }
        }


        public IEnumerable<MealSchedule> GetMealScheduleForProfile(Profile profile)
        {
            var meals = _mealRepository.GetAllMealsForProfile(profile);

            var schedule = new List<MealSchedule>();

            for (int d = 0; d < 28; d++)
            {
                var day = DateTime.Today.AddDays(d);

                var scheduleDay = new MealSchedule(day);

                foreach (var time in profile.SelectedTimes.OrderBy(t => t))
                {
                    var meal = meals.Where(m => m.Day == day).Where(m => m.Time == time).FirstOrDefault();

                    var toAdd = meal ?? new Meal(day, time);
                    scheduleDay.Meals.Add(toAdd);
                }

                schedule.Add(scheduleDay);
            }

            return schedule;
        }
    }
}