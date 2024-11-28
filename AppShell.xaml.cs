using DayPlanner.Views;

namespace DayPlanner
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NoteListPage),typeof(NoteListPage));
            Routing.RegisterRoute(nameof(NoteEditPage), typeof(NoteEditPage));
        }
    }
}