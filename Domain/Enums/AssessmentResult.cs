using System.ComponentModel;

namespace Domain.Enums
{
    public enum AssessmentResult
    {
        [Description("Passed the assessment")]
        Pass = 1,

        [Description("Failed the assessment")]
        Fail = 2,

        [Description("Assessment not taken")]
        NotTaken = 3
    }
}