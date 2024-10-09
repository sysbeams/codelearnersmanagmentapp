using System.ComponentModel;

namespace Domain.Enums
{
    public enum CourseMode
    {
        [Description("Course conducted entirely online")]
        Virtual = 1,

        [Description("Course with both online and in-person components")]
        Hybrid = 2,

        [Description("Course conducted entirely in-person")]
        Physical = 3
    }

}