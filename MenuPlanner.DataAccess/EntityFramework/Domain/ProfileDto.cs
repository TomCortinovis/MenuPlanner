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
    [Table("Profiles")]
    public class ProfileDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int SelectedTimes { get; set; }

        public virtual ICollection<MealDto> Meals { get; set; }
    }
}
