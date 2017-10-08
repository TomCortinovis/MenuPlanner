using MenuPlanner.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuPlanner.UI.Managers
{
    public interface IPaginationManager
    {
        int PageSize { get; set; }

        int CurrentPage { get; set; }

        int TotalNumberOfElements { get; set; }

        bool HasPreviousData { get; }

        bool HasNextData { get; }

        void GoNext();

        void GoBack();
    }
}
