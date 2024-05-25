
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public record CreateStudentRequest(
    [Required] string FirstName, 
    [Required] string LastName,
    [Required] string PhoneNumber,
    [Required] string EmailAddress 
);
