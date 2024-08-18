using Application.Commands;
using Application.Contracts.Services;
using Application.Dtos;
using Application.Queries;
using Domain.Aggreagtes.CourseAggregate;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseAssessmentController(IMediator _mediator) : ControllerBase
    {
        // GET: api/<CourseAssessmentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CourseAssessmentController>/5
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var request = await _mediator.Send(new GetCourse.Query { Id = id });
            return Ok(request);
        }
        /*d046da53-a36d-4da7-fe9f-08dcbfb40c5d*/
        // POST api/<CourseAssessmentController>
        [HttpPost]
        public async Task<ActionResult<CourseAssessmentResponseModel>> NewCourseAssessment([FromBody] CreateCourseAssessmentCommand request)
        {
            var courseAssessment = await _mediator.Send(request);
            return CreatedAtAction(nameof(GetCourse), new { id = courseAssessment.Id}, null);
        }

        // PUT api/<CourseAssessmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CourseAssessmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
