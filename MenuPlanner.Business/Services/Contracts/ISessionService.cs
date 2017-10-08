using MenuPlanner.Business.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.Business.Services.Contracts
{
    public interface ISessionService
    {
        event EventHandler<Profile> ProfileChanged;

        Profile CurrentProfile { get; set; }
    }
}
