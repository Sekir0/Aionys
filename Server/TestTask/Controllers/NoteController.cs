using System;
using System.Threading.Tasks;
using TestTask.Data;
using TestTask.Domain;
using TestTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NoteModel>> Get()
        {
            return Ok(await _noteService.GetNotes());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteModel>> GetById([FromRoute] Guid id)
        {
            var note = await _noteService.GetNoteById(id);

            if (note == null)
                return NotFound();

            return Ok(note);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            if (await _noteService.GetNoteById(id) == null)
            {
                return NotFound();
            }

            await _noteService.DeleteNote(id);

            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NoteModel>> Update([FromRoute] Guid id,[FromBody] NoteModel model)
        {
            if (await _noteService.GetNoteById(id) == null)
            {
                return NotFound();
            }

            await _noteService.UpdateNote(id, model.Note);

            return Ok(await _noteService.GetNoteById(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<NoteModel>> Create([FromBody] NoteModel model)
        {
            var created = new NoteEntity
            {
                Id = Guid.NewGuid(),
                Note = model.Note
            };

            await _noteService.CreateNote(created);

            return Ok(await _noteService.GetNoteById(created.Id));
        }
    }
}
