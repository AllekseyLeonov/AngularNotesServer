using Application.Actions.Notes;
using FluentValidation;

namespace Application.Validation.Validators;

public class EditNoteCommandValidator: AbstractValidator<EditNoteCommand>
{
    public EditNoteCommandValidator()
    {
        RuleFor(x => x.Model.Id).NotEmpty().NotNull();
        RuleFor(x => x.Model.Title).NotEmpty().MaximumLength(NoteParameters.TitleMaxLength);
        RuleFor(x => x.Model.Description).NotEmpty().MaximumLength(NoteParameters.DescriptionMaxLength);
        RuleFor(x => x.Model.Date).Length(NoteParameters.DateLength);
    }
}