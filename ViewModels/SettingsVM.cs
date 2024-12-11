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

        partial void OnThemeChanged(string value)
        {
            if (value != null)
            {
                Application.Current.Resources[nameof(Theme)] = value;
                ApplyTheme(value);
            }
        }

        private void ApplyTheme(string themeName)
        {
            ResourceDictionary newTheme = themeName switch
            {
                "BlueTheme" => new Resources.Themes.BlueTheme(),
                "WhiteTheme" => new Resources.Themes.WhiteTheme(),
                "DarkTheme" => new Resources.Themes.DarkTheme(),
                _ => new Resources.Themes.WhiteTheme()
            };

            var currentTheme = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(rd => rd is Resources.Themes.BlueTheme || rd is Resources.Themes.WhiteTheme || rd is Resources.Themes.DarkTheme);

            if (currentTheme != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(currentTheme);
            }

            Application.Current.Resources.MergedDictionaries.Add(newTheme);
        }

        [RelayCommand]
        private void SaveSettings()
        {
            Preferences.Set(nameof(this.FontFamily), this.FontFamily);
            Preferences.Set(nameof(this.FontSize), this.FontSize);
            Preferences.Set(nameof(this.Theme), this.Theme);
        }

        [RelayCommand]
        private void ResetSettings()
        {
            FontSize = StyleRegistry.DefeaultFontSize;
            FontFamily = StyleRegistry.DefeaultFontFamily;
            Theme = StyleRegistry.DefeaultTheme;

            Preferences.Remove(nameof(this.FontFamily));
            Preferences.Remove(nameof(this.FontSize));
            Preferences.Remove(nameof(this.Theme));
        }

        public SettingsVM(INavigationService navigationService) : base(navigationService)
        {
            //Шрифты
            this.Fonts = new ObservableCollection<string>(StyleRegistry.Fonts.Keys);

            this.FontSize = Preferences.Get(nameof(this.FontSize), StyleRegistry.DefeaultFontSize);
            this.FontFamily = Preferences.Get(nameof(this.FontFamily), StyleRegistry.DefeaultFontFamily);

            //Темы
            this.Themes = new ObservableCollection<string>(StyleRegistry.Themes);

            this.Theme = Preferences.Get(nameof(this.Theme), StyleRegistry.DefeaultTheme);
        }
    }
}
