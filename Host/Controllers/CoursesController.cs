﻿using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Application.Commands.CreateCourse;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseCommand command)
        {
            var course = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateCourse), new { id = course.Id }, course);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetCourse(Guid id)
        {
            var request = await _mediator.Send(new GetCourse.Query { Id = id });
            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses([FromQuery] GetCourses.Query query)
        {
            var courses = await _mediator.Send(query);
            return Ok(courses);
        }
    }
}
