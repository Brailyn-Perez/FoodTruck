using FluentValidation;

namespace FoodTruck.Core.Application.Features.User.Commands.CreateUserCommand
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(p => p.email)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(50);

            RuleFor(p => p.password)
                .NotEmpty()
                .MaximumLength(50);

            
        }
    }
}
