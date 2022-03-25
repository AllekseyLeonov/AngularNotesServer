using Domain;
using Persistence.Interfaces;
using MediatR;

namespace Application.Actions.Notes;

public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, Note>
{
    private readonly IGenericRepository<Note> _database;

    public CreateNoteCommandHandler(IGenericRepository<Note> database)
    {
        _database = database;
    }

    public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var guidId = Guid.NewGuid();
        var note = new Note
        {
            Id = guidId.ToString(),
            Title = request.Title,
            Description = request.Description,
            Date = DateOnly.FromDateTime(DateTime.Now).ToString()
        };

        await _database.CreateAsync(note);
        return note;
    }
}