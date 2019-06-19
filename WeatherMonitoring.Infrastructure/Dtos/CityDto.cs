using Dapper.Contrib.Extensions;
using System;
using WeatherMonitoring.Domain.Extensions;

namespace WeatherMonitoring.Infrastructure.Dtos
{
    [Table("City")]
    public class CityDto
    {
        [ExplicitKey]
        public Guid? Id { get; }

        public string NameGuid { get; }

        public bool Active { get; }

        public CityDto(string nameGuid, bool active)
        {
            if(nameGuid.IsNullOrWhiteSpaces())
                throw new ArgumentNullException(nameof(nameGuid));

            NameGuid = nameGuid;
            Active = active;
        }

        public CityDto(Guid? id, string nameGuid, bool active)
        {
            if (id == Guid.Empty)
                throw new ArgumentNullException(nameof(id));

            if (nameGuid.IsNullOrWhiteSpaces())
                throw new ArgumentNullException(nameof(nameGuid));

            Id = id;
            NameGuid = nameGuid;
            Active = active;
        }
    }
}
