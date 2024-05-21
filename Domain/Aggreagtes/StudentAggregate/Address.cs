using Domain.Common.Contracts;

namespace Domain.Aggreagtes.StudentAggregate
{
    public class Address : AuditableEntity<Guid>
    {
        public string Street { get; set; }

        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string Country { get; set; } = default!;
        internal Address(string street, string city, string state, string country)
        {
            City = city;
            State = state;
            Country = country;
            Street = street;
        }
    }
}
