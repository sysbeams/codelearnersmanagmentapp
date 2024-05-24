using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record CreateStudentResponse(string studentNumber, string firstname, string lastname, string phoneNumber, string emailAddress, string Address, string sponsorName)
    {

    }
}
