using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.API.Validators;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Interfaces.Features.Course.Commands;
using StudentCourseSystem.Application.Interfaces.Features.Course.Queries;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Courses;

namespace StudentCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IGetAllCoursesQuery _getAllCoursesQuery;
        private readonly IGetCourseByIdQuery _getCourseByIdQuery;
        private readonly ICreateCourseCommand _createCourseCommand;
        private readonly IUpdateCourseCommand _updateCourseCommand;
        private readonly IDeleteCourseCommand _deleteCourseCommand;

        public CourseController(
            IGetAllCoursesQuery getAllCoursesQuery,
            IGetCourseByIdQuery getCourseByIdQuery,
            ICreateCourseCommand createCourseCommand,
            IUpdateCourseCommand updateCourseCommand,
            IDeleteCourseCommand deleteCourseCommand)
        {
            _getAllCoursesQuery = getAllCoursesQuery;
            _getCourseByIdQuery = getCourseByIdQuery;
            _createCourseCommand = createCourseCommand;
            _updateCourseCommand = updateCourseCommand;
            _deleteCourseCommand = deleteCourseCommand;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _getAllCoursesQuery.ExecuteAsync();
            return Ok(courses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            var course = await _getCourseByIdQuery.ExecuteAsync(id);
            if (course == null)
                return NotFound($"Course with ID {id} not found.");
            return Ok(course);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseCreateDto courseDto)
        {
            await _createCourseCommand.ExecuteAsync(courseDto);
            return Ok("Course created successfully.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, [FromBody] CourseUpdateDto courseDto)
        {
            await _updateCourseCommand.ExecuteAsync(id, courseDto);
            return Ok("Course updated successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            await _deleteCourseCommand.ExecuteAsync(id);
            return Ok("Course deleted successfully.");
        }
    }
}
