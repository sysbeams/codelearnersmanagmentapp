using System.ComponentModel;

namespace Domain.Enums
{
   public enum AssessmentType
    {
        [Description("Written examination")]
        Exam = 1,

        [Description("Practical assessment")]
        Practicals = 2,

        [Description("Oral or visual presentation")]
        Presentations = 3
    }
}