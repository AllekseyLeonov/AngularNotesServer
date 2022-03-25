using Domain;
using MediatR;

namespace Application.Actions.Notes;

public class EditNoteCommand : IRequest<Note>
{
    public Note Model;

    public EditNoteCommand(Note model)
    {
        Model = model;
    }
}