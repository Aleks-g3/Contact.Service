using Contact.Service.Context;
using FluentValidation;

namespace Contact.Service.API.Entities.Validators
{
    public class ContactDTOValidator : AbstractValidator<ContactDTO>
    {
        public ContactDTOValidator(ContactDbContext dbContext)
        {
            RuleFor(m=>m.Email).NotEmpty().EmailAddress();
            RuleFor(m=>m.Name).NotEmpty();
            RuleFor(m=>m.PhoneNumber).NotEmpty();
            RuleFor(m=>m.Category).NotEmpty();
            RuleFor(m => m.Password).NotEmpty().MinimumLength(6);

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
