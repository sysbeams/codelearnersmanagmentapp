using Domain.Enums;

namespace Domain.Aggreagtes.CourseAggregate
{
    public class CourseModeDetails
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public CourseMode Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public CourseModeDetails(CourseMode name, string description, decimal price)
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
