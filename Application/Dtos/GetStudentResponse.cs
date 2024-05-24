using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
     public class GetStudentResponse(string message, bool isSuccessful, CreateStudentResponse Data) : BaseResponse(message, isSuccessful)
    {

    }
}
