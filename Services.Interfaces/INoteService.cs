using Domain.Core;

namespace Services.Interfaces;

public interface INoteService
{
    List<Note> GetNotes();
    Task<Note> CreateNote(Note note);
    Task<Note> DeleteNote(int noteId);
    Task<Note> EditNote(Note note);
    Task<int> GenerateNewId();
}