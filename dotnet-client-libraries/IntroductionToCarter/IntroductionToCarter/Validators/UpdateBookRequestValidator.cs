using FluentValidation;
using IntroductionToCarter.Contracts;

namespace IntroductionToCarter.Validators;

public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
{
    public UpdateBookRequestValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty();
        RuleFor(x => x.Author).NotNull().NotEmpty();
        RuleFor(x => x.ISBN).NotNull().NotEmpty();
    }
}
