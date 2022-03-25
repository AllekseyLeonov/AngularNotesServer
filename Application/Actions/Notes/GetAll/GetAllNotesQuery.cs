using Domain;
using MediatR;

namespace Application.Actions.Notes;

public class GetAllNotesQuery : IRequest<IEnumerable<Note>> { }