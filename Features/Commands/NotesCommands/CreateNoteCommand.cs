using Domain.Core;
using Domain.Interfaces;
using MediatR;

namespace Features.Commands.NotesCommands;

public record CreateNoteDto(string Title, string Description);

public class CreateNoteCommand : IRequest<Note>
{
    public CreateNoteDto Model;
    
    public CreateNoteCommand(CreateNoteDto model)
    {
        Model = model;
    }
}

public class CreateNoteHandler: IRequestHandler<CreateNoteCommand, Note>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateNoteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Note> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = new Guid(),
            Title = request.Model.Title,
            Description = request.Model.Description,
            Date = DateOnly.FromDateTime(DateTime.Now).ToString()
        };
        
        await _unitOfWork.Notes.CreateAsync(note);
        return note;
    }
}