using System;

namespace WeatherMonitoring.Infrastructure.Repositories.SqlClientFactory
{
    public class SqlClientFactory : ISqlClientFactory
    {
        public string ConnectionString { get; }

        public SqlClientFactory(string connectionString)
        {
            ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
        }

        public string GetConnection()
        {
            return ConnectionString;
        }
    }
}
