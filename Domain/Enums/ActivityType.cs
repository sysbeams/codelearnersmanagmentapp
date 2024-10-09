using System.ComponentModel;

namespace Domain.Enums
{
    public enum ActivityType
    {
        [Description("Exercise activity")]
        Exercise = 1,

        [Description("Assignment activity")]
        Assignment = 2,

        [Description("Class Participation activity")]
        ClassParticipation = 3
    }
}