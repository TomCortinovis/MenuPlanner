using MenuPlanner.Utils.Transverse;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.DataAccess.EntityFramework.Domain
{
    [Table("Meals")]
    public class MealDto
    {
        [Key]
        public int Id { get; set; }

        public DateTime Day { get; set; }

        public TimeSlot Time { get; set; }

        public string Title { get; set; }

        public virtual ProfileDto Profile { get; set; }
    }
}
