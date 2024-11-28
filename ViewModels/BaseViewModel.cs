using CommunityToolkit.Mvvm.ComponentModel;
using DayPlanner.Services;

namespace DayPlanner.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        #region Protected Fields

        protected readonly INavigationService NavigationService;

        #endregion Protected Fields

        #region Public Constructors

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        #endregion Public Constructors
    }
}