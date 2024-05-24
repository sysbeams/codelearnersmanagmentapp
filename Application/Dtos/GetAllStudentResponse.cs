using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class GetAllStudentResponse(string message, bool isSuccessful, IEnumerable<CreateStudentResponse> Data) : BaseResponse(message, isSuccessful)
    {

    }
}
