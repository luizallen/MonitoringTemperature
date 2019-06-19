namespace WeatherMonitoring.Infrastructure.Repositories.SqlClientFactory
{
    public interface ISqlClientFactory
    {
        string GetConnection();
    }
}