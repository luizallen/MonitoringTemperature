using Newtonsoft.Json;
using System;
using System.Diagnostics.CodeAnalysis;

namespace WeatherMonitoring.Infrastructure.Serializers
{
    [ExcludeFromCodeCoverage]
    public class CustomJsonConverter : ICustomSerialization
    {
        public string Serialize<TRequest>(TRequest content)
        {
            return JsonConvert.SerializeObject(content, Settings);
        }

        public object Deserialize(string content, Type typeExpected)
        {
            return JsonConvert.DeserializeObject(content, typeExpected, Settings);
        }

        private JsonSerializerSettings Settings => new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore
        };
    }
}
