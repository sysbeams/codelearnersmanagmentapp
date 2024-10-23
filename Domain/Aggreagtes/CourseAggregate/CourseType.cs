using Domain.Enums;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseType
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public CourseType Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public CourseType(CourseType name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
