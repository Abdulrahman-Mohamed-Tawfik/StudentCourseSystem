using FluentValidation;
using StudentCourseSystem.DTOs.Students;

namespace StudentCourseSystem.API.Validators
{
    public class StudentCreateDtoValidator : AbstractValidator<StudentCreateDto>
    {
        public StudentCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("Name is required")
                 .MaximumLength(100).WithMessage("Name cannot exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone Number is required")
                .Length(11).WithMessage("Phone Number Must be 11 digits");

            RuleFor(x => x.Gender)
                .NotEmpty().WithMessage("Gender is required")
                .Must(g => g == 'M' || g == 'F').WithMessage("Gender must be 'M' or 'F'");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of Birth is required");

        }
    }
}
