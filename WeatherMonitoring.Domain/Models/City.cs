using System;
using WeatherMonitoring.Domain.Extensions;

namespace WeatherMonitoring.Domain.Models
{
    public class City
    {
        public Guid Id { get; }

        public string Name { get; }

        public bool Active { get; }

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
