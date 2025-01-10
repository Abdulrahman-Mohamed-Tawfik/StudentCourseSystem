using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.API.Validators;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Courses;

namespace StudentCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            try
            {
                return Ok(await _courseRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourseById(int id)
        {
            try
            {
                var course = await _courseRepository.GetAsync(s => s.Id == id);
                if (course == null)
                {
                    return NotFound();
                }
                return Ok(course);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse([FromBody] CourseCreateDto courseDto)
        {
            try
            {
                var validator = new CourseCreateDtoValidator();
                var validationResult = await validator.ValidateAsync(courseDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var course = _mapper.Map<Course>(courseDto);
                course.IsDeleted = false; // Default value for new courses

                await _courseRepository.CreateAsync(course);

                return Ok("Course created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourseById(int id, [FromBody] CourseUpdateDto courseDto)
        {
            try
            {
                var validator = new CourseUpdateDtoValidator();
                var validationResult = await validator.ValidateAsync(courseDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var course = (await _courseRepository.GetAsync(c => c.Id == id)).FirstOrDefault();
                if (course == null)
                    return NotFound($"Course with ID {id} not found.");

                if (courseDto.Name != null)
                    course.Name = courseDto.Name;

                if (courseDto.Description != null)
                    course.Description = courseDto.Description;

                if (courseDto.CreditHours.HasValue)
                    course.CreditHours = courseDto.CreditHours.Value;

                await _courseRepository.SaveChangesAsync();

                return Ok("Course updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourseById(int id)
        {
            try
            {
                var success = await _courseRepository.DeletePhysicallyAsync(id);
                if (!success)
                {
                    return NotFound($"Course with ID {id} not found.");
                }
                return Ok("Course is Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
