using REP_CRIME01.Crime.Domain.Common;
using System;
using System.Collections.Generic;

namespace REP_CRIME01.Crime.Domain.ValueObjects
{
    public class EventPlace : ValueObject<EventPlace>
    {
        public string City { get; }
        public string Street { get; }

        public EventPlace(string city, string street)
        {
            if (string.IsNullOrWhiteSpace(city) || string.IsNullOrWhiteSpace(street))
                throw new ArgumentException("Arguments for place of event cannot be null or empty string");

            City = city;
            Street = street;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return City;
            yield return Street;
        }
    }
}
