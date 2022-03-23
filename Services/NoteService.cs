using Domain.Core;
using Domain.Interfaces;
using Services.Interfaces;

namespace Services;

public class NoteService : INoteService
{
    private readonly IUnitOfWork _unitOfWork;
    public NoteService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public List<Note> GetNotes()
    {
        return _unitOfWork.Notes.GetAllAsync().Result.ToList();
    }

    public async Task<Note> CreateNote(Note note)
    {
        await _unitOfWork.Notes.CreateAsync(note);
        return note;
    }

    public async Task<Note> DeleteNote(Guid noteId)
    {
        var note = _unitOfWork.Notes.GetAsync(noteId).Result;
        await _unitOfWork.Notes.DeleteAsync(note);
        return note;
    }
    
    public async Task<Note> EditNote(Note note)
    {
        await _unitOfWork.Notes.UpdateAsync(note);
        return note;
    }

    public async Task<Guid> GenerateNewId()
    {
        return new Guid();
    }
}