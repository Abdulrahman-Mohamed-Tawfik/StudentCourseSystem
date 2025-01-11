using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.API.Validators;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Commands;
using StudentCourseSystem.Application.Interfaces.Features.StudentCourse.Queries;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.StudentCourse;

namespace StudentCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCourseController : ControllerBase
    {
        private readonly IGetTopGradesForAllCourses _getTopGradesForAllCourses;
        private readonly IGetTopGradesForCourseQuery _getTopGradesForCourseQuery;
        private readonly IMapper _mapper;
        private readonly ICreateStudentCourseCommand _createStudentCourseCommand;


        public StudentCourseController(IGetTopGradesForAllCourses getTopGradesForAllCourses,
            IGetTopGradesForCourseQuery getTopGradesForCourseQuery,
            IMapper mapper,
            ICreateStudentCourseCommand createStudentCourseCommand)
        {
            _getTopGradesForAllCourses = getTopGradesForAllCourses;
            _getTopGradesForCourseQuery = getTopGradesForCourseQuery;
            _mapper = mapper;
            _createStudentCourseCommand = createStudentCourseCommand;
        }

        [HttpGet("top-grades")]
        public async Task<IActionResult> GetTopGradesForAllCourses()
        {
            try
            {
                var result = await _getTopGradesForAllCourses.ExecuteAsync();
                if (!result.Any())
                {
                    return NotFound($"No students found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("top-grades/{courseId}")]
        public async Task<IActionResult> GetTopGradesForCourse(int courseId)
        {
            try
            {
                var result = await _getTopGradesForCourseQuery.ExecuteAsync(courseId);
                if (!result.Any())
                {
                    return NotFound($"No students found for course ID {courseId}.");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentCourse(StudentCourseCreateDto studentCourseCreateDto)
        {
            try
            {
                var validator = new StudentCourseCreateDtoValidator();
                var validationResult = await validator.ValidateAsync(studentCourseCreateDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var studentCourse = _mapper.Map<StudentCourseEntity>(studentCourseCreateDto);
                await _createStudentCourseCommand.ExecuteAsync(studentCourse);
                return Ok("StudentCourse created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
