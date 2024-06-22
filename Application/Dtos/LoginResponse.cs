using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos;
    public record LoginResponse(

        string EmailAddress,
        string Message,
        bool IsSuccessful
    ) : BaseResponse(Message, IsSuccessful);


