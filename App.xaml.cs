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
            Resources.Add(nameof(SettingsVM.Theme), Theme);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}