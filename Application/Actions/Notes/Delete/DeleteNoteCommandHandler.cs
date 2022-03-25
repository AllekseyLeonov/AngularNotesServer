using Domain;
using MediatR;
using Persistence.Interfaces;

namespace Application.Actions.Notes;

public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand, Note>
{
    private readonly IGenericRepository<Note> _database;

    public DeleteNoteCommandHandler(IGenericRepository<Note> database)
    {
        _database = database;
    }

    public async Task<Note> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = _database.GetAsync(request.Id).Result;
        await _database.DeleteAsync(note);
        return note;
    }
}