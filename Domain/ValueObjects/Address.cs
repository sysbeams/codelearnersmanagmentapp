using Domain.Common.Contracts;

namespace Domain.ValueObjects
{
    public class Address
    {
        public int StreetNo { get; private set; } = default!;
        public string StreetName { get; private set; } = default!;
        public string City { get; private set; } = default!;
        public string State { get; private set; } = default!;
        public string Country { get; private set; } = default!;

        #region Constructor
        private Address() { }
        internal Address(int streetNo, string streetName, string city, string state, string country)
        {
            StreetNo = streetNo;
            StreetName = streetName;
            City = city;
            State = state;
            Country = country;
        }
        #endregion

        #region Behaviour
        public static Address CreateAddress(int streetNo, string streetName, string city, string state, string country) 
            => new Address(streetNo, streetName, city, state, country);
        public void UpdateStreetNumber(int streetNo) => StreetNo = streetNo;
        public void UpdateStreetName(string streetName) => StreetName = streetName;
        public void UpdateCity(string city) => City = city;
        public void UpdateState(string state) => State = state;
        public void UpdateCountry(string country) => Country = country;
        public override int GetHashCode() => HashCode.Combine(StreetNo, StreetName, City, State, Country);
        public override bool Equals(object obj)
        {
            if (obj is not Address other) return false;
            return StreetNo == other.StreetNo &&
                StreetName == other.StreetName &&
                City == other.City &&
                State == other.State &&
                Country == other.Country;
        }
        #endregion
    }
}
