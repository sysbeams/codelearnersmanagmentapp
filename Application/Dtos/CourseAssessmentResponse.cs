using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record CourseAssessmentResponse
        (DateTime AssessmentDate,
        string Message,
        Guid CourseId,
        bool IsSuccessful) : BaseResponse(Message, IsSuccessful);
   
}
