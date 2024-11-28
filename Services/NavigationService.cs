namespace DayPlanner.Services
{
    public class NavigationService : INavigationService
    {
        public Task NavigateToAsync(string route, IDictionary<string, object> parameters)
        {
            if (parameters != null)
            {
                return Shell.Current.GoToAsync(route, parameters);
            }

            else
            {
                return Shell.Current.GoToAsync(route);
            }
        }
    }
}
