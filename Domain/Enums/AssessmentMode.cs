using System.ComponentModel;

namespace Domain.Enums
{
   public enum AssessmentMode
    {
        [Description("Online assessment")]
        Online = 1, 

        [Description("Virtual assessment")]
        Virtual = 2
    }

}