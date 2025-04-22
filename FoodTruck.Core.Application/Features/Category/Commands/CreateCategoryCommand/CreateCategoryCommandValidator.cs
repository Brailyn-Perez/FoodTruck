using FluentValidation;

namespace FoodTruck.Core.Application.Features.Category.Commands.CreateCategoryCommand
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(50)
                .MinimumLength(3)
                .NotNull()
                ;
            RuleFor(p => p.Description)
                .MaximumLength(250);

        }
    }
}
