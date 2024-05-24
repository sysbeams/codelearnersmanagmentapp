
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public record CreateStudentRequest
{
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }

    [Required]
    public string EmailAddress { get; set; }
}
