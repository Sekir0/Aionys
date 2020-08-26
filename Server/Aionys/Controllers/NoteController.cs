using Aionys.Contractss;
using Aionys.Contractss.Requests;
using Aionys.Contractss.Responses;
using Aionys.DAL.Domain;
using Aionys.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Aionys.Helpers;

namespace Aionys.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;
        private readonly IUriService _uriService;


        public NoteController(INoteService noteService, IMapper mapper, IUriService uriService)
        {
            _noteService = noteService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// return all notes or a specified number of notes
        /// </summary>
        /// <param name="paginationQuery">paginator parameters</param>
        [HttpGet(ApiRouts.Notes.GetAll)]
        public async Task<IActionResult> GetAll([FromQuery]PaginationQuery paginationQuery)
        {
            var pagination = _mapper.Map<PaginationFilter>(paginationQuery);
            var notes = await _noteService.GetNotes(pagination);
            var noteResponse = _mapper.Map<List<NoteResponse>>(notes);

            if (pagination == null || pagination.PageNumber < 1 || pagination.PageSize < 1)
            {
                return Ok(new PagedResponse<NoteResponse>(noteResponse));
            }

            var paginationResponse = PaginationHelpers.CreatePaginatedResponse(_uriService, pagination, noteResponse);
            return Ok(paginationResponse);
        }

        /// <summary>
        /// get note by id
        /// </summary>
        /// <param name="noteId">note Id</param>
        /// <returns>returns note by id</returns>
        [HttpGet(ApiRouts.Notes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid noteId)
        {
            var note = await _noteService.GetNoteById(noteId);

            return Ok(new Response<NoteResponse>(_mapper.Map<NoteResponse>(note)));
        }

        /// <summary>
        /// update note by Id
        /// </summary>
        /// <param name="noteId">note Id</param>
        /// <returns>update - bool if true update note, false - NotFound</returns>
        [HttpPut(ApiRouts.Notes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid noteId, [FromBody] UpdateNoteRequest request)
        {
            var note = await _noteService.GetNoteById(noteId);
            note.Name = request.Name;

            var update = await _noteService.UpdateNote(note);

            if(update)
                return Ok(new Response<NoteResponse>(_mapper.Map<NoteResponse>(note)));

            return NotFound();
        }

        /// <summary>
        /// deleted note by id
        /// </summary>
        /// <param name="noteId">note Id</param>
        /// <returns>deleted - bool if = true deleted, else return NotFound</returns>
        [HttpDelete(ApiRouts.Notes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid noteId)
        {
            var deleted = await _noteService.DeleteNote(noteId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Сcreate new note
        /// </summary>
        /// <param name="noteRequest">Name</param>
        /// <returns>return created note</returns>
        [HttpPost(ApiRouts.Notes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest noteRequest)
        {
            var note = new Note { Name = noteRequest.Name };

            await _noteService.CreateNote(note);

            var locationUri = _uriService.GetNoteUri(note.Id.ToString());
            return Created(locationUri, new Response<NoteResponse>(_mapper.Map<NoteResponse>(note)));
        }
    }
}
