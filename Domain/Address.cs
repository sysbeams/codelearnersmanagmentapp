namespace Domain
{
    public class Address
    {

        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string LocalGovernment { get; set; } = default!;
        public Address(string city, string state, string localGovernment)
        {
            City = city;
            State = state;
            LocalGovernment = localGovernment;
        }
    }
}
