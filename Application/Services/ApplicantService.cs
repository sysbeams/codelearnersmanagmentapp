using Application.Contracts.Services;
using Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ApplicantService : IApplicantService
    {

        public Task<BaseResponse> RegisterApplicant(CreateApplicantRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
