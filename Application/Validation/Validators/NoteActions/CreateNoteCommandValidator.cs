using Application.Actions.Notes;
using FluentValidation;

namespace Application.Validation.Validators;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(NoteParameters.TitleMaxLength);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(NoteParameters.DescriptionMaxLength);
    }
}