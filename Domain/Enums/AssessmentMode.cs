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
        [Description(nameof(Virtual))]
        Virtual = 1,
        [Description(nameof(Onsite))]
        Onsite = 2,
        [Description(nameof(Hybrid))]
        Hybrid = 3,

    }
}
