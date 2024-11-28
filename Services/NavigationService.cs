namespace DayPlanner.Services
{
    public class NavigationService : INavigationService
    {
        #region Public Methods

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

        #endregion Public Methods
    }
}