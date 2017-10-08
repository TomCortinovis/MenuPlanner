using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.BusinessObjects
{
    public class MealSchedule
    {
        public DateTime Day { get; set; }

        public List<Meal> Meals { get; set; }

        public MealSchedule(DateTime day)
        {
            Day = day;
            Meals = new List<Meal>();
        }

        public MealSchedule(MealSchedule schedule)
        {
            var newSchedule = new MealSchedule(schedule.Day);

            newSchedule.Meals = new List<Meal>();
            foreach (var meal in schedule.Meals)
            {
                newSchedule.Meals.Add(new Meal(meal.Day, meal.Time, meal.Title));
            }
        }
    }
}
