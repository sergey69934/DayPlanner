namespace DayPlanner.Services
{
    public static class StyleRegistry
    {
        //Шрифты
        public static readonly Dictionary<string, string> Fonts = new()
        {
            { "Cornerita", "Cornerita-Thin.ttf" },
            { "Ebbe", "Ebbe-Thin.ttf" },
            { "Karsten", "Karsten-Thin.ttf" }
        };

        public static readonly double DefeaultFontSize = 16.0;

        public static readonly string DefeaultFontFamily = Fonts.Keys.First();

        //Темы
        public static readonly List<string> Themes = new()
        {
            "BlueTheme",
            "DarkTheme",
            "WhiteTheme"
        };

        public static readonly string DefeaultTheme = Themes[0];
    }
}
