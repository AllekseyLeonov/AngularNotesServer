using Application.Actions.Notes;
using FluentValidation;

namespace Application.Validation.Validators;

public class DeleteNoteCommandValidator: AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}