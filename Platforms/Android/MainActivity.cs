using Android.App;
using Android.Content.PM;
using Android.OS;

namespace DayPlanner
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Скрыть Status Bar
            Window.DecorView.SystemUiVisibility = Android.Views.StatusBarVisibility.Hidden;

            // Полноэкранный режим
            Window.SetFlags(Android.Views.WindowManagerFlags.Fullscreen,  Android.Views.WindowManagerFlags.Fullscreen);
        }
    }
}
