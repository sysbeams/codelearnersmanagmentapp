using Domain.Enums;

namespace Domain.Aggreagtes.CourseAggregate
{
<<<<<<<< HEAD:Domain/Aggreagtes/CourseAggregate/CourseModeDetails.cs
    public class CourseModeDetails
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public CourseMode Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public CourseModeDetails(CourseMode name, string description, decimal price)
========
    public class CourseType
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public CourseType Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }

        public CourseType(CourseType name, string description, decimal price)
>>>>>>>> origin/develop:Domain/Aggreagtes/CourseAggregate/CourseType.cs
        {
            Name = name;
            Description = description;
            Price = price;
        }
    }
}
