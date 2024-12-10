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
        private double _fontSize;

        [ObservableProperty]
        private string _fontFamily;

        partial void OnFontFamilyChanged(string value)
        {
            if (value != null)
            {
                Application.Current.Resources[nameof(FontFamily)] = value;
            }
        }

        partial void OnFontSizeChanged(double value)
        {
            if (value != null)
            {
                Application.Current.Resources[nameof(FontSize)] = value;
            }
        }

            [RelayCommand]
            private void SaveSettings()
            {
                Preferences.Set(nameof(FontFamily), FontFamily);
                Preferences.Set(nameof(FontSize), FontSize);
            }

            [RelayCommand]
            private void ResetSettings()
            {
                Preferences.Remove(nameof(FontFamily));
                Preferences.Remove(nameof(FontSize));
            }

        public SettingsVM(INavigationService navigationService) : base(navigationService)
        {
            Fonts = new ObservableCollection<string>(FontRegistry.Fonts.Keys);

            FontSize = Preferences.Get(nameof(FontSize), FontRegistry.DefeaultFontSize);
            FontFamily = Preferences.Get(nameof(FontFamily), FontRegistry.DefeaultFontFamily);
        }
    }
}
