using Domain.Core;

namespace Services.Interfaces;

public interface INoteService
{
    List<Note> GetNotes();
    Task<Note> CreateNote(Note note);
    Task<Note> DeleteNote(Guid noteId);
    Task<Note> EditNote(Note note);
    Task<Guid> GenerateNewId();
}