using Domain;
using MediatR;

namespace Application.Actions.Notes;

public class CreateNoteCommand : IRequest<Note>
{
    public string Title;
    public string Description;

    public CreateNoteCommand(string title, string description)
    {
        Title = title;
        Description = description;
    }
}