using System.ComponentModel;

namespace Domain.Enums
{
   public enum ApplicationStatus
    {
        [Description("New application")]
        New = 1,

        [Description("Application scheduled")]
        Scheduled = 2,

        [Description("Application accepted")]
        Accepted = 3,

        [Description("Applicant admitted")]
        Admitted = 4,

        [Description("Application rejected")]
        Rejected = 5,

        [Description("Application cancelled")]
        Cancelled = 6
    }

}