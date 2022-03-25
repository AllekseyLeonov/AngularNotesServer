using Application.Interfaces;
using Domain;
using MediatR;

namespace Application.Actions.Notes;

public class GetAllNotesQueryHandler: IRequestHandler<GetAllNotesQuery, IEnumerable<Note>>
{
    private readonly IGenericRepository<Note> _database;
    
    public GetAllNotesQueryHandler(IGenericRepository<Note> database)
    {
        _database = database;
    }
    
    public async Task<IEnumerable<Note>> Handle(GetAllNotesQuery request, CancellationToken cancellationToken)
    {
        var notes = await _database.GetAllAsync();
        return notes as IEnumerable<Note>;
    }
}