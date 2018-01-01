using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.DataAccess.EntityFramework.Domain
{
    [Table("ItemTypes")]
    public class ItemTypeDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
