
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

//output Dtos
public  record  StudentDto (string studentNumber, string firstname, string lastname, string phoneNumber, string emailAddress, string Address,string sponsorName);
public record  StudentResponse(string message, bool isSuccessful, StudentDto Data) : BaseResponse(message, isSuccessful);
public record StudentsResponse(string message, bool isSuccessful, IEnumerable<StudentDto>  Data) : BaseResponse(message, isSuccessful);

//input Dtos

//create student
public class CreateStudentrequest
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
