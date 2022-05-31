using FluentValidation;

namespace Contact.Service.API.Entities.Validators
{
    public class LoginUserDTOValidator : AbstractValidator<LoginUserDTO>
    {
        public LoginUserDTOValidator()
        {
            RuleFor(m=>m.Email).NotEmpty();
            RuleFor(m=>m.Password).NotEmpty();
        }
    }
}
