using Dapper.Contrib.Extensions;
using System;
using WeatherMonitoring.Domain.Extensions;

namespace WeatherMonitoring.Infrastructure.Dtos
{
    [Table("City")]
    public class CityDto
    {
        [ExplicitKey]
        public Guid? Id { get; private set; }

        public string Name { get; private set; }

        public bool Active { get; private set; }

        public CityDto(string nameGuid, bool active)
        {
            if(nameGuid.IsNullOrWhiteSpaces())
                throw new ArgumentNullException(nameof(nameGuid));

            Id = Guid.NewGuid();
            Name = nameGuid;
            Active = active;
        }

        public CityDto(Guid? id, string name, bool active)
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
