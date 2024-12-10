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
            //Шрифты
            Fonts = new ObservableCollection<string>(StyleRegistry.Fonts.Keys);

            FontSize = Preferences.Get(nameof(FontSize), StyleRegistry.DefeaultFontSize);
            FontFamily = Preferences.Get(nameof(FontFamily), StyleRegistry.DefeaultFontFamily);

            //Темы
            Themes = new ObservableCollection<string>(StyleRegistry.Themes);

            Theme = Preferences.Get(nameof(Theme), StyleRegistry.DefeaultTheme);
        }
    }
}
