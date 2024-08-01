using Application.Contracts.Services;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService applicantService;
        public ApplicantController(IApplicantService applicant) => applicantService = applicant;

        [HttpGet("{id}")]
        [OpenApiOperation("Get An Applicant Details", "")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var applicant = applicantService.GetApplicantById(id);
            return Ok(applicant);

        }

        [HttpPost("Register")]
        [OpenApiOperation("Register An Applicant", "")]
        public async Task<IActionResult> RegisterApplicant([FromBody]CreateApplicantRequest createApplicantRequest)
        {
            var applicant = await applicantService.RegisterApplicant(createApplicantRequest);
               return Ok(applicant);

        }
    }
}
