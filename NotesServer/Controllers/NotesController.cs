using Application.Actions.Notes;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotesServer.DTOs;

namespace NotesServer.Controllers;

[ApiController]
[Route("[controller]")]
public class NotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public NotesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("/getAll")]
    public async Task<IEnumerable<Note>> GetNotes()
    {
        var query = new GetAllNotesQuery();
        var response = await _mediator.Send(query);
        return response;
    }

    [HttpPost("/createNote")]
    public async Task<Note> AddNote(NoteDto noteDto)
    {
        var command = new CreateNoteCommand(noteDto.Title, noteDto.Description);
        var response = await _mediator.Send(command);
        return response;
    }

    [HttpDelete("/deleteNote")]
    public async Task<Note> DeleteNote(string noteId)
    {
        var command = new DeleteNoteCommand(Guid.Parse(noteId));
        var response = await _mediator.Send(command);
        return response;
    }

    [HttpPatch("/editNote")]
    public async Task<Note> EditNote(Note note)
    {
        var command = new EditNoteCommand(note);
        var response = await _mediator.Send(command);
        return response;
    }
}