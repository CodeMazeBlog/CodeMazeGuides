using FluentValidation;
using IntroductionToCarter.Contracts;

namespace IntroductionToCarter.Validators;

public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
{
    public CreateBookRequestValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Author).NotNull().NotEmpty();
        RuleFor(x => x.ISBN).NotNull().NotEmpty();
    }
}
