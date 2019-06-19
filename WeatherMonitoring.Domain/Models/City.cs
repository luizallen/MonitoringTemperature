using Newtonsoft.Json;
using System;
using WeatherMonitoring.Domain.Extensions;

namespace WeatherMonitoring.Domain.Models
{
    public class City
    {
        public Guid Id { get; private set; }

        [JsonProperty("localidade")]
        public string Name { get; private set; }

        public bool Active { get; private set; }

        public City() {}

        public City(Guid id, string name, bool active)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            if (name.IsNullOrWhiteSpaces())
                throw new ArgumentNullException(nameof(name));

            Id = id;
            Name = name;
            Active = active;
        }
    }
}
