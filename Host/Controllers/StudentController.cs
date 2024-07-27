using Application.Contracts.IStudentService;
using Application.Dtos;
using Microsoft.AspNetCore.Http;
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

        [HttpGet]
        [OpenApiOperation("Get A Student Details", "")]
        public async Task<StudentResponse> GetByStudentNumber(string studentNumber)
        {
            return await _studentService.GetStudentByStudentNumber(studentNumber);
        }

    }
}
