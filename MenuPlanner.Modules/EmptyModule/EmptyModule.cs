using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Modules.EmptyModule
{
    public class EmptyModule : IModule
    {
        public string Name => "";

        public int Order => 1;
    }
}
