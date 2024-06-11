using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Services
{
    public interface IApplicantService
    {
        Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request);
    }
}
