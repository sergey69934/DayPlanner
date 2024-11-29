using CommunityToolkit.Mvvm.ComponentModel;
using DayPlanner.Services;

namespace DayPlanner.ViewModels
{
    public partial class SettingsVM : BaseViewModel
    {
        [ObservableProperty]
        private DateTime _selectedDate;

        [ObservableProperty]
        private string _selectedColorScheme;

        [ObservableProperty]
        private double _fontSize;

        [ObservableProperty]
        private string _selectedFontFamily;

        public SettingsVM(INavigationService navigationService) : base(navigationService)
        {

        }
    }
}
