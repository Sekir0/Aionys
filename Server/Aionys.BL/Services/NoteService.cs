using Aionys.DAL.Domain;
using Aionys.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aionys.BL.Services
{
    public class NoteService : INoteService
    {
        private readonly DataContext _dataContext;

        public NoteService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <summary>
        /// Delete Note
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns></returns>
        public async Task <bool> DeleteNote(Guid noteId)
        {
            var note = await GetNoteById(noteId);

            if (note == null)
                return false;

            _dataContext.Notes.Remove(note);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        /// <summary>
        /// Get note by id
        /// </summary>
        /// <param name="noteId">Note Id</param>
        /// <returns></returns>
        public async Task<Note> GetNoteById(Guid noteId)
        {
            return await _dataContext.Notes.SingleOrDefaultAsync(x => x.Id == noteId);
        }

        /// <summary>
        /// Get all notes
        /// </summary>
        /// <returns>all notes</returns>
        public async Task<List<Note>> GetNotes(PaginationFilter paginationFilter = null)
        {
            if(paginationFilter == null)
            {
                return await _dataContext.Notes.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            return await _dataContext.Notes.Skip(skip).Take(paginationFilter.PageSize).ToListAsync();
        }

        /// <summary>
        /// Update note
        /// </summary>
        /// <param name="updateNote">name note to update</param>
        /// <returns>if updated > 0 return true</returns>
        public async Task<bool> UpdateNote(Note updateNote)
        {
            _dataContext.Notes.Update(updateNote);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        /// <summary>
        /// Create note
        /// </summary>
        /// <param name="note">note name</param>
        /// <returns>if created > 0 return true</returns>
        public async Task<bool> CreateNote(Note note)
        {
            await _dataContext.Notes.AddAsync(note);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
