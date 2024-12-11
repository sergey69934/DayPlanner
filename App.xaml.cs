using DayPlanner.Services;
using DayPlanner.ViewModels;

namespace DayPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Загрузка сохранённых настроек
            var fontFamily = Preferences.Get(nameof(SettingsVM.FontFamily), StyleRegistry.DefeaultFontFamily);
            var fontSize = Preferences.Get(nameof(SettingsVM.FontSize), StyleRegistry.DefeaultFontSize);
            var theme = Preferences.Get(nameof(SettingsVM.Theme), StyleRegistry.DefeaultTheme);
            var date = Preferences.Get(nameof(SettingsVM.Date), DateTime.Now);

            // Обновление ресурсов
            StyleManager.UpdateResource(nameof(SettingsVM.FontFamily), fontFamily);
            StyleManager.UpdateResource(nameof(SettingsVM.FontSize), fontSize);
            StyleManager.UpdateResource(nameof(SettingsVM.Theme), theme);
            StyleManager.UpdateResource(nameof(SettingsVM.Date), date);
            StyleManager.ApplyTheme(theme);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}