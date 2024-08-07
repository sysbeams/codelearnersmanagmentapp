
using Domain.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public record CreateStudentRequest(
    [Required] string PhoneNumber,
    [Required] string Street,
    [Required] string City,
    [Required] string State,
    [Required] string Country,
    [Required] EducationLevel EducationLevel,
    [Required] string SponsorName,
    [Required] string SponsorEmailAddress,
    [Required] string SponsorPhoneNumber,
    [Required] Guid ApplicantId

);
