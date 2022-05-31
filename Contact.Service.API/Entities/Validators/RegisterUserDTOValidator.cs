using Contact.Service.Context;
using FluentValidation;

namespace Contact.Service.API.Entities.Validators
{
    public class RegisterUserDTOValidator : AbstractValidator<RegisterUserDTO>
    {
        public RegisterUserDTOValidator(ContactDbContext dbContext)
        {
            RuleFor(m => m.Email).NotEmpty().EmailAddress();
            
            RuleFor(m => m.Password).MinimumLength(6);
            
            RuleFor(m => m.ConfirmPassword).Equal(m => m.Password);
            
            RuleFor(m => m.Email)
                .Custom((value, context) =>
                {
                    var emailInUse = dbContext.Users.Any(u => u.Email == value);
                    if (emailInUse)
                    {
                        context.AddFailure("Email", "That email is taken");
                    }
                });
        }
    }
}
