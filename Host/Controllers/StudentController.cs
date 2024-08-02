using Application.Contracts.IStudentService;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
       public StudentController(IStudentService student) => _studentService = student;

        [HttpGet("StudentNumber")]
        [OpenApiOperation("Get A Student Details", "")]
        public async Task<StudentResponse> GetByStudentNumber(string studentNumber)
        {
            return await _studentService.GetStudentByStudentNumber(studentNumber);
        }

        [HttpGet("email")]
        [OpenApiOperation("Get A Student Details", "")]
        public async Task<IActionResult> GetStudentByEmail(string email) 
        {
           var student = await _studentService.GetStudentByEMail(email);
           return Ok(student);
        }
       
        [HttpPost("Register")]
        [OpenApiOperation("RegisterStudent", "")] 
        public async Task<IActionResult> RegisterStudent([FromBody] CreateStudentRequest request)
        {
            var student = await _studentService.RegisterStudent(request);
            return Ok(student);
        }
    }
}
