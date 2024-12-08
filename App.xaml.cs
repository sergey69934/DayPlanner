namespace DayPlanner
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Resources.Add("GlobalFontFamily", "Cornerita");
            Resources.Add("GlobalFontSize", 14);
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}