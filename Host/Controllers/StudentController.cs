using Application.Commands;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using static Application.Commands.CreateStudent;


namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator) => _mediator = mediator;

        [HttpGet("StudentNumber")]
        [OpenApiOperation("Get A Student Details", "Get A Student Details Using Student Unique Number")]
        public async Task<IActionResult> GetByStudentNumber(string studentNumber)
        {
            var student = await _mediator.Send(new GetStudentNumber.Query { StudentNumber = studentNumber });
            return Ok(student);
        }

        [HttpGet("Email")]
        [OpenApiOperation("Get A Student Details", "Get A Student Details Using EMail")]
        public async Task<IActionResult> GetStudentByEmail(string email) 
        {
            var student= await _mediator.Send(new GetStudentEmail.Query { EmailAddress = email });
            return Ok(student);
        }
       
        [HttpPost("Register")]
        [OpenApiOperation("RegisterStudent", "Register A New Student")] 
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateStudent), new { studentNumber = student.StudentNumber }, student);
            
        }

        [HttpGet("All")]
        [OpenApiOperation("Get All Students", "Get All Student Using Query")]
        public async Task<IActionResult> GetAllStudents([FromQuery] GetStudents.Query query)
        {
            var students = await _mediator.Send(query);
            return Ok(students);
        }
    }
}
