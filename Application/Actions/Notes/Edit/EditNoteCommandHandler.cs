using Domain;
using MediatR;
using Persistence.Interfaces;

namespace Application.Actions.Notes;

public class EditNoteCommandHandler : IRequestHandler<EditNoteCommand, Note>
{
    private readonly IGenericRepository<Note> _database;

    public EditNoteCommandHandler(IGenericRepository<Note> database)
    {
        _database = database;
    }

    public async Task<Note> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        await _database.UpdateAsync(request.Model);
        return request.Model;
    }
}