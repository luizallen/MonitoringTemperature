namespace WeatherMonitoring.Domain.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpaces(this string value)
            => string.IsNullOrWhiteSpace(value);
    }
}
