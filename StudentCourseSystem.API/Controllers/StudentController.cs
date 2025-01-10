using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.API.Validators;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Students;

namespace StudentCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                return Ok(await _studentRepository.GetAllAsync());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            try
            {
                var student = await _studentRepository.GetAsync(s => s.Id == id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentCreateDto studentDto)
        {
            try
            {
                var validator = new StudentCreateDtoValidator();
                var validationResult = await validator.ValidateAsync(studentDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var student = _mapper.Map<Student>(studentDto);
                student.IsDeleted = false; // Default value for new students

                await _studentRepository.CreateAsync(student);

                return Ok("Student created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudentById(int id, [FromBody] StudentUpdateDto studentDto)
        {
            try
            {
                var validator = new StudentUpdateDtoValidator();
                var validationResult = await validator.ValidateAsync(studentDto);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                var student = (await _studentRepository.GetAsync(s => s.Id == id)).FirstOrDefault();
                if (student == null)
                    return NotFound($"Student with ID {id} not found.");

                // Update only the provided fields
                if (studentDto.Name != null)
                    student.Name = studentDto.Name;
                if (studentDto.Email != null)
                    student.Email = studentDto.Email;
                if (studentDto.Password != null)
                    student.Password = studentDto.Password;
                if (studentDto.Gender != null)
                    student.Gender = studentDto.Gender;

                await _studentRepository.SaveChangesAsync();

                return Ok("Student updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            try
            {
                var success = await _studentRepository.DeletePhysicallyAsync(id);
                if (!success)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return Ok("Student is Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
