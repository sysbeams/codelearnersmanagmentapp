using Application.Contracts.Services;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController(IApplicantService applicantService) : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var applicant = applicantService.GetApplicantById(id);
            return Ok(applicant);

        }




        [HttpPost("CreateApplicant")]
        public IActionResult CreateApplicant([FromBody]CreateApplicantRequest createApplicantRequest)
        {
            var applicant = applicantService.RegisterApplicant(createApplicantRequest);
                return CreatedAtAction(nameof(GetById),new {applicant.Id},null);

        }
    }
}
