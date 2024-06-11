using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;

    public record LoginRequest(
        [Required] string EmailAddress,
        [Required] string Password
        );
