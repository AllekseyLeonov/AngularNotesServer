using Domain.Core;
using Domain.Interfaces;
using MediatR;

namespace Features.Commands.NotesCommands;

public class DeleteNoteCommand : IRequest<Note>
{
    public Guid Id;

    public DeleteNoteCommand(Guid id)
    {
        Id = id;
    }
}

public class DeleteNoteHandler : IRequestHandler<DeleteNoteCommand, Note>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteNoteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Note> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var note = _unitOfWork.Notes.GetAsync(request.Id).Result;
        await _unitOfWork.Notes.DeleteAsync(note);
        return note;
    }
}