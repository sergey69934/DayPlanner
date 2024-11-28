using CommunityToolkit.Mvvm.ComponentModel;
using DayPlanner.Services;

namespace DayPlanner.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        protected readonly INavigationService NavigationService;

        public BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
