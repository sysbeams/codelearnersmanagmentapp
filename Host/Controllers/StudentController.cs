using Application.Contracts.IStudentService;
using Application.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentService studentService) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> RegisterStudent([FromBody] CreateStudentRequest requestModel)
        {
            var studentResponseObject = await studentService.RegisterStudent(requestModel);
            
            return CreatedAtAction(nameof(GetById), new { studentResponseObject.StudentNumber}, null);
        }

        [HttpGet("{studentNumber}")]
        public async Task<ActionResult<StudentResponse?>> GetById([FromRoute] string studentNumber)
        {
            var studentResponseObject = await studentService.GetStudentByStudentNumber(studentNumber);

            return Ok(studentResponseObject);
        }
    }
}
