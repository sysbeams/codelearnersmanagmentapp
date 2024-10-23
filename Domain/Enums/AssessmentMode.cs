using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
