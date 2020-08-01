﻿using Aionys.Contracts;
using Aionys.Contracts.Requests;
using Aionys.Contracts.Responses;
using Aionys.DAL.Domain;
using Aionys.BL.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace Aionys.Controllers
{
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        private readonly IMapper _mapper;

        /// <summary>
        /// magic DI
        /// </summary>
        /// <param name="noteService"></param>
        public NoteController(INoteService noteService, IMapper mapper)
        {
            _noteService = noteService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns>all note</returns>
        [HttpGet(ApiRouts.Notes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteService.GetNotes();
            
            return Ok(_mapper.Map<List<NoteResponse>>(notes));
        }

        /// <summary>
        /// Get note by id
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>single note what we search</returns>
        [HttpGet(ApiRouts.Notes.GetById)]
        public async Task<IActionResult> GetById([FromRoute] Guid noteId)
        {
            var note = await _noteService.GetNoteById(noteId);

            if (note == null)
                return NotFound();

            return Ok(_mapper.Map<NoteResponse>(note));
        }

        /// <summary>
        /// Note update
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <param name="request">request for update note</param>
        /// <returns>updated note</returns>
        [HttpPut(ApiRouts.Notes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid noteId, [FromBody] UpdateNoteRequest request)
        {
            var note = await _noteService.GetNoteById(noteId);
            note.Name = request.Name;

            var update = await _noteService.UpdateNote(note);

            if(update)
                return Ok(_mapper.Map<NoteResponse>(note));

            return NotFound();
        }

        /// <summary>
        /// Delete note
        /// </summary>
        /// <param name="noteId">note id</param>
        /// <returns>must delete note or return no content</returns>
        [HttpDelete(ApiRouts.Notes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid noteId)
        {
            var deleted = await _noteService.DeleteNote(noteId);

            if (deleted)
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="noteRequest">request to create note</param>
        /// <returns>response for create note</returns>
        [HttpPost(ApiRouts.Notes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest noteRequest)
        {
            var note = new Note { Name = noteRequest.Name };

            await _noteService.CreateNote(note);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseUrl + "/" + ApiRouts.Notes.GetById.Replace("{noteId}", note.Id.ToString());

            return Created(locationUrl, _mapper.Map<NoteResponse>(note));
        }
    }
}
