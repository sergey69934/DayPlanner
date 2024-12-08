using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DayPlanner.Services;
using System.Collections.ObjectModel;

namespace DayPlanner.ViewModels
{
    public partial class SettingsVM : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<string> _fonts;

        [ObservableProperty]
        private double _currentFontSize;

        [ObservableProperty]
        private string _currentFontFamily;

        partial void OnCurrentFontFamilyChanged(string value)
        {
            if (value != null)
            {
                Application.Current.Resources["GlobalFontFamily"] = value;
            }
        }

        partial void OnCurrentFontSizeChanged(double value)
        {
            if (value != null)
            {
                Application.Current.Resources["GlobalFontSize"] = value;
            }
        }

        [RelayCommand]
        private void SaveSettings()
        {
            Preferences.Set("FontFamily", CurrentFontFamily);
            Preferences.Set("FontSize", CurrentFontSize);
        }

        [RelayCommand]
        private void ResetSettings()
        {
            Preferences.Remove("FontFamily");
            Preferences.Remove("FontSize");
        }

        public SettingsVM(INavigationService navigationService) : base(navigationService)
        {
            Fonts = new ObservableCollection<string>(){
                "Cornerita",
                "Ebbe",
                "Karsten"
            };

            CurrentFontSize = Preferences.Get("FontSize", 16.0);
            CurrentFontFamily = Preferences.Get("FontFamily", "Arial");
        }
    }
}
