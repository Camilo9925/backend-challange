using Challenge.Domain.Entities;
using FluentValidation;

namespace Challenge.Application.Validator;

public class InputToolValidator : AbstractValidator<InputTool>
{
    public InputToolValidator()
    {
        RuleFor(tool => tool.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(100).WithMessage("Title can have a maximum of 100 characters.");

        RuleFor(tool => tool.Link)
            .NotEmpty().WithMessage("Link is required.");

        RuleFor(tool => tool.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description can have a maximum of 500 characters.");

        RuleFor(tool => tool.Tags)
            .NotEmpty().WithMessage("At least one tag is required.");
    }
}
