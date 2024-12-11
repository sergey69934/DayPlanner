namespace DayPlanner.Services
{
    public static class StyleManager
    {
        public static void ApplyTheme(string themeName)
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

        public static void UpdateResource(string key, object value)
        {
            if (Application.Current.Resources.ContainsKey(key))
            {
                Application.Current.Resources[key] = value;
            }
            else
            {
                Application.Current.Resources.Add(key, value);
            }
        }
    }
}
