using System.Threading.Tasks;
using TestTask.Domain;
using TestTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTask.Helpers;

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
        public async Task<ActionResult> Get()
        {
            return Ok(await _noteService.GetNotesAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById([FromRoute] string id)
        {
            var note = await _noteService.GetByIdAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete([FromRoute] string id)
        {
            if (await _noteService.GetByIdAsync(id) == null)
            {
                return NotFound();
            }

            await _noteService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteUpdateViewModel>> Update([FromRoute] string id,[FromBody] NoteUpdateViewModel model)
        {
            var result = await _noteService.UpdateAsync(id, model.Content);

            if (result.Successed)
            {
                return NoContent();
            }

            return BadRequest(result.ToProblemDetails());
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<NoteCreateViewModel>> Create([FromBody] NoteCreateViewModel model)
        {
            var (result, id) = await _noteService.CreateAsync(model.Content);

            if (result.Successed)
            {
                return Created(Url.Action("GetById", new { id }), await _noteService.GetByIdAsync(id));
            }

            return BadRequest(result.ToProblemDetails());
        }
    }
}
