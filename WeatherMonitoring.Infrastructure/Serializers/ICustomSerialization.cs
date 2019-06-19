using System;

namespace WeatherMonitoring.Infrastructure.Serializers
{
    public interface ICustomSerialization
    {
        string Serialize<TRequest>(TRequest content);

        object Deserialize(string content, Type typeExpected);
    }
}
