using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

public record CreateStudentResponse(
    string StudentNumber,
    string Firstname,
    string Lastname,
    string PhoneNumber,
    string EmailAddress,
    string Address,
    string SponsorName
    );
