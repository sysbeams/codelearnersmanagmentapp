using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Mode
    {
        [Description(nameof(Online))]
        Online = 1,
        [Description(nameof(Virtual))]
        Virtual = 2,
        [Description(nameof(Onsite))]
        Onsite = 3,
    }
}
