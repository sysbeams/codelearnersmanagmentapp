using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;
    public record CreateApplicantRequest(
        [Required] string FirstName,
        [Required] string LastName,
        [Required] string UserName,
        [Required] string EmailAddress,
        [Required] string Password,
        [Required] string ConfirmPassword
    );

