using System.Globalization;

namespace DayPlanner.Services
{
    public class DateTimeToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime dateTime)
            {
                return dateTime.TimeOfDay; // Преобразуем DateTime в TimeSpan
            }
            return TimeSpan.Zero;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is TimeSpan timeSpan)
            {
                // Возвращаем DateTime с текущей датой и указанным временем
                return DateTime.Today + timeSpan;
            }
            return DateTime.MinValue;
        }
    }
}
