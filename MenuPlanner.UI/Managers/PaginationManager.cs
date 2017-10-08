using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MenuPlanner.UI.Models;
using GalaSoft.MvvmLight;

namespace MenuPlanner.UI.Managers
{
    public class PaginationManager : ObservableObject, IPaginationManager
    {
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; }
            set { Set(ref _currentPage, value); }
        }

        private int _pageSize;
        public int PageSize
        {
            get { return _pageSize; }
            set { Set(ref _pageSize, value); }
        }

        public int TotalNumberOfElements { get; set; }

        public bool HasNextData => CurrentPage * PageSize < TotalNumberOfElements;

        public bool HasPreviousData => CurrentPage > 1;

        public PaginationManager()
        {
            CurrentPage = 1;
        }

        public void GoBack()
        {
            CurrentPage--;
            RaisePropertyChanged(() => HasNextData);
            RaisePropertyChanged(() => HasPreviousData);
        }

        public void GoNext()
        {
            CurrentPage++;
            RaisePropertyChanged(() => HasNextData);
            RaisePropertyChanged(() => HasPreviousData);
        }
    }
}
