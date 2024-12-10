using DayPlanner.Services;
using DayPlanner.ViewModels;

namespace DayPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Получение сохранённых данных (шрифт, стиль)
            string fontFamily = Preferences.Get(nameof(SettingsVM.FontFamily), StyleRegistry.DefeaultFontFamily);
            double fontSize = Preferences.Get(nameof(SettingsVM.FontSize), StyleRegistry.DefeaultFontSize);
            string Theme = Preferences.Get(nameof(SettingsVM.Theme), StyleRegistry.DefeaultTheme);

            // Добавление ресурсов
            Resources.Add(nameof(SettingsVM.FontFamily), fontFamily);
            Resources.Add(nameof(SettingsVM.FontSize), fontSize);

            ResourceDictionary newTheme = Theme switch
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

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}