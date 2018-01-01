using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.DataAccess.EntityFramework.Domain
{
    [Table("Stock")]
    public class StockItemDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quantity { get; set; }

        public virtual ItemTypeDto Type { get; set; }

        public virtual ProfileDto Profile { get; set; }


    }
}
