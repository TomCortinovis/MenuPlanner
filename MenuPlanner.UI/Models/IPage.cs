using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.UI.Models
{
    public interface IPage
    {
        string Name { get; }

        int Order { get; }
    }
}
