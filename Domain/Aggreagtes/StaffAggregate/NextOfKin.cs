public class NextOfKin
{
    public string Name { get; private set; }
    public string Relationship { get; private set; }
    public string PhoneNumber { get; private set; }

    public NextOfKin(string name, string relationship, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name), "Name cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(relationship))
        {
            throw new ArgumentNullException(nameof(relationship), "Relationship cannot be null or empty.");
        }

        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            throw new ArgumentNullException(nameof(phoneNumber), "Phone number cannot be null or empty.");
        }

        Name = name;
        Relationship = relationship;
        PhoneNumber = phoneNumber;
    }
}














