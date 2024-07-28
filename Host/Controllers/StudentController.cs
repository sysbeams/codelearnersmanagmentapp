using Application.Contracts.IStudentService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetStudentByEmail(string email) 
        {
           var student = await _studentService.GetStudentByEMail(email);
           return Ok(student);
        }
       
    }
}
