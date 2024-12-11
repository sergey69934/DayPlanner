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

        [ObservableProperty]
        private ObservableCollection<string> _themes;

        [ObservableProperty]
        private string _theme;

        [ObservableProperty]
        private DateTime _date;

        partial void OnFontFamilyChanged(string value)
        {
            if (value != null)
            {
                StyleManager.UpdateResource(nameof(FontFamily), value);
            }
        }

        partial void OnFontSizeChanged(double value)
        {
            if (value != null)
            {
                StyleManager.UpdateResource(nameof(FontSize), value);
            }
        }

        partial void OnThemeChanged(string value)
        {
            if (value != null)
            {
                StyleManager.ApplyTheme(value);
            }
        }

        partial void OnDateChanged(DateTime value)
        {
            StyleManager.UpdateResource(nameof(Date), value);
        }

        [RelayCommand]
        private void SaveSettings()
        {
            Preferences.Set(nameof(this.FontFamily), this.FontFamily);
            Preferences.Set(nameof(this.FontSize), this.FontSize);
            Preferences.Set(nameof(this.Theme), this.Theme);
            Preferences.Set(nameof(this.Date), this.Date);
        }

        [RelayCommand]
        private void ResetSettings()
        {
            this.FontSize = StyleRegistry.DefeaultFontSize;
            this.FontFamily = StyleRegistry.DefeaultFontFamily;
            this.Theme = StyleRegistry.DefeaultTheme;

            Preferences.Remove(nameof(this.FontFamily));
            Preferences.Remove(nameof(this.FontSize));
            Preferences.Remove(nameof(this.Theme));
            Preferences.Remove(nameof(this.Date));
        }

        public SettingsVM(INavigationService navigationService) : base(navigationService)
        {
            //Шрифты
            this.Fonts = new ObservableCollection<string>(StyleRegistry.Fonts.Keys);
            this.Themes = new ObservableCollection<string>(StyleRegistry.Themes);

            this.FontSize = Preferences.Get(nameof(this.FontSize), StyleRegistry.DefeaultFontSize);
            this.FontFamily = Preferences.Get(nameof(this.FontFamily), StyleRegistry.DefeaultFontFamily);
            this.Theme = Preferences.Get(nameof(this.Theme), StyleRegistry.DefeaultTheme);

            this.Date = Preferences.Get(nameof(this.Date), DateTime.Now);
        }
    }
}
