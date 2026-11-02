using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class ArgumentNullOrEmptyException : BaseDomainException
    {

        public ArgumentNullOrEmptyException(string message) : base(message)
        {
            
        }
    }
}
