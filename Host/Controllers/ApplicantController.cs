using Microsoft.AspNetCore.Mvc;
using Application.Contracts.Services;
using Application.Dtos;
using NSwag.Annotations;
using Infrastructure.Persistence.Initialization;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly IApplicantService _applicantService;
        private readonly ICustomSeeder _applicantSeeder;

        public ApplicantController(IApplicantService applicantService,ICustomSeeder applicantSeeder)
        {
            _applicantService = applicantService;
            _applicantSeeder = applicantSeeder;
        }

        [HttpGet("{id}")]
        [OpenApiOperation("Get An Applicant Details", "")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var applicant = await _applicantService.GetApplicantById(id);
            return Ok(applicant);
        }

        [HttpPost("Register")]
        [OpenApiOperation("Register An Applicant", "")]
        public async Task<IActionResult> RegisterApplicant([FromBody] CreateApplicantRequest createApplicantRequest)
        {
            var applicant = await _applicantService.RegisterApplicant(createApplicantRequest);
            return Ok(applicant);
        }

        [HttpGet("All")]
        [OpenApiOperation("Get All Applicants", "")]
        public async Task<IActionResult> GetAllApplicants()
        {
            var applicants = await _applicantService.GetAllApplicantsAsync();
            return Ok(applicants);
        }

        [HttpPost("Seed")]
        [OpenApiOperation("Seed Fake Applicants Data", "")]
        public async Task<IActionResult> SeedApplicants()
        {
           await _applicantSeeder.InitializeAsync();
            return Ok("Fake applicants data has been generated.");
        }
    }
}
