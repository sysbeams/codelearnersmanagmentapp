using System.ComponentModel;

namespace Domain.Enums
{
    public enum AssessmentStatus
    {
        [Description("New assessment created")]
        New = 1,

        [Description("Assessment has been taken")]
        Taken = 2,

        [Description("Assessment is currently under review")]
        InReview = 3,

        [Description("Assessment passed successfully")]
        Pass = 4,

        [Description("Assessment failed")]
        Fail = 5
    }

}