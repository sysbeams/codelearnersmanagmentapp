using Microsoft.AspNetCore.Mvc;
using Application.Contracts.Services;
using Application.Dtos;
using NSwag.Annotations;
using Infrastructure.Persistence.Initialization;
using MediatR;
using Application.Commands;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Application.Commands.CreateApplicant;
using Application.Queries;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicantController : ControllerBase
    {
        private readonly ICustomSeeder _applicantSeeder;
        private readonly IMediator _mediator;


        public ApplicantController(IMediator mediator, ICustomSeeder applicantSeeder)
        {
            _mediator = mediator;
            _applicantSeeder = applicantSeeder;
        }

        [HttpGet("{id:guid}")]
        [OpenApiOperation("Get An Applicant Details", "Get An Applicant Details Using ID")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var request = await _mediator.Send(new GetApplicant.Query { Id = id });
            return Ok(request);
        }

        [HttpPost("Register")]
        [OpenApiOperation("Register An Applicant", "Creating a New Applicant")]
        public async Task<IActionResult> RegisterApplicant([FromBody] CreateApplicantCommand command)
        {
            var applicant= await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateApplicant), new { id = applicant.ID }, applicant);
           
        }

        [HttpGet("All")]
        [OpenApiOperation("Get All Applicants", "Get All Applicant Using Query")]
        public async Task<IActionResult> GetAllApplicants([FromQuery] GetApplicants.Query query)
        {
            var applicants = await _mediator.Send(query);
            return Ok(applicants);
        }

        [HttpPost("Seed")]
        [OpenApiOperation("Seed Fake Applicants Data", "Applicant Data Seeding")]
        public async Task<IActionResult> SeedApplicants()
        {
           await _applicantSeeder.InitializeAsync();
            return Ok("Fake applicants data has been generated.");
        }
    }
}
