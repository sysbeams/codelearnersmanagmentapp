using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public record CreateStudentResponse(
    string StudentNumber,
    string FirstName,
    string LastName,
    string PhoneNumber,
    string EmailAddress,
    string Address,
    string SponsorName,
    string Message, 
    bool IsSuccessful
    ) : BaseResponse(Message, IsSuccessful);
