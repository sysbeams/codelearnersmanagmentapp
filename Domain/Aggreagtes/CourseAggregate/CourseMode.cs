using Domain.Enums;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseMode
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Mode Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public CourseMode(Mode name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }

        
        public void UpdatePrice(decimal newPrice)
        {
            Price = newPrice;
        }


    }
}
