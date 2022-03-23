using Domain.Core;
using Domain.Interfaces;
using MediatR;

namespace Features.Commands.NotesCommands;

public class EditNoteCommand : IRequest<Note>
{
    public Note Model;

    public EditNoteCommand(Note model)
    {
        Model = model;
    }
}

public class EditNoteHandler : IRequestHandler<EditNoteCommand, Note>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditNoteHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Note> Handle(EditNoteCommand request, CancellationToken cancellationToken)
    {
        await _unitOfWork.Notes.UpdateAsync(request.Model);
        return request.Model;
    }
}