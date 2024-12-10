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
            string fontFamily = Preferences.Get(nameof(SettingsVM.FontFamily), FontRegistry.DefeaultFontFamily);
            double fontSize = Preferences.Get(nameof(SettingsVM.FontSize), FontRegistry.DefeaultFontSize);

            // Добавление ресурсов
            Resources.Add(nameof(SettingsVM.FontFamily), fontFamily);
            Resources.Add(nameof(SettingsVM.FontSize), fontSize);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}