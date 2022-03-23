using Domain.Core;
using Domain.Interfaces;
using MediatR;

namespace Features.Queries.NotesQueries;

public class GetAllNotesQuery : IRequest<IEnumerable<Note>> { }

public class GetAllNotesHandler : IRequestHandler<GetAllNotesQuery, IEnumerable<Note>>
{
    private readonly IUnitOfWork _database;
    
    public GetAllNotesHandler(IUnitOfWork database)
    {
        _database = database;
    }
    
    public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _database.Notes.GetAllAsync();
        return notes as IEnumerable<Note>;
    }
}