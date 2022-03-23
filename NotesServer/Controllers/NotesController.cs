using Domain.Core;
using Microsoft.AspNetCore.Mvc;
using NotesServer.DTOs;
using Services.Interfaces;

namespace NotesServer.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly INoteService _noteService;

    public NotesController(INoteService noteService)
    {
        _noteService = noteService;
    }

    [HttpGet("/getAll")]
    public List<Note> GetNotes()
    {
        return _noteService.GetNotes();
    }

    [HttpPost("/createNote")]
    public async Task<Note> AddNote(CreateRequestNoteDto noteDto)
    {
        var note = new Note
        {
            Id = await _noteService.GenerateNewId(),
            Title = noteDto.Title,
            Description = noteDto.Description,
            Date = DateOnly.FromDateTime(DateTime.Now).ToString()
        };
        return await _noteService.CreateNote(note);
    }

    [HttpDelete("/deleteNote")]
    public async Task<Note> DeleteNote(string noteId)
    {
        return await _noteService.DeleteNote(Guid.Parse(noteId));
    }
    
    [HttpPatch("/editNote")]
    public async Task<Note> EditNote(Note note)
    {
        return await _noteService.EditNote(note);
    }
}