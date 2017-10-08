using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Modules
{
    public interface IModule
    {
        string Name { get; }

        int Order { get; }
    }
}
