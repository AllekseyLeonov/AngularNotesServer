using Domain;
using MediatR;

namespace Application.Actions.Notes;

public class DeleteNoteCommand : IRequest<Note>
{
    public Guid Id;

    public DeleteNoteCommand(Guid id)
    {
        Id = id;
    }
}