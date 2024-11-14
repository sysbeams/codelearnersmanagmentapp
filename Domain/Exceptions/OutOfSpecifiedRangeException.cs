using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class OutOfSpecifiedRangeException(string message) : BaseDomainException(message)
    {
    }
}
