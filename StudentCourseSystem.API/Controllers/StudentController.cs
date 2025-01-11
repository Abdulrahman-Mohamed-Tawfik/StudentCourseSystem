using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentCourseSystem.API.Validators;
using StudentCourseSystem.Application.Interfaces;
using StudentCourseSystem.Application.Interfaces.Features.Student.Commands;
using StudentCourseSystem.Application.Interfaces.Features.Student.Queries;
using StudentCourseSystem.Domain.Models;
using StudentCourseSystem.DTOs.Students;

namespace StudentCourseSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //IStudentRepository _studentRepository;
        private readonly IMapper _mapper;
        private readonly IGetAllStudentsQuery _getAllStudentsQuery;
        private readonly IGetStudentByIdQuery _getStudentByIdQuery;
        private readonly ICreateStudentCommand _createStudentCommand;
        private readonly IUpdateStudentCommand _updateStudentCommand;
        private readonly IDeleteStudentCommand _deleteStudentCommand;

        public StudentController(
            IGetAllStudentsQuery getAllStudentsQuery,
            IGetStudentByIdQuery getStudentByIdQuery,
            ICreateStudentCommand createStudentCommand,
            IUpdateStudentCommand updateStudentCommand,
            IDeleteStudentCommand deleteStudentCommand,
            IMapper mapper)
        {
            _getAllStudentsQuery = getAllStudentsQuery;
            _getStudentByIdQuery = getStudentByIdQuery;
            _createStudentCommand = createStudentCommand;
            _updateStudentCommand = updateStudentCommand;
            _deleteStudentCommand = deleteStudentCommand;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                var students = await _getAllStudentsQuery.ExecuteAsync();
                return Ok(students);
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
                var student = await _getStudentByIdQuery.ExecuteAsync(id);
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

                var student = _mapper.Map<StudentEntity>(studentDto);
                student.IsDeleted = false; // Default value for new students

                await _createStudentCommand.ExecuteAsync(student);

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

                await _updateStudentCommand.ExecuteAsync(id, studentDto);

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
                var success = await _deleteStudentCommand.ExecuteAsync(id);
                if (!success)
                {
                    return NotFound($"Student with ID {id} not found.");
                }
                return Ok("Student deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



    }
}
