using Aionys.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Aionys.BL.Services
{
    /// <summary>
    /// Abstracts for NoteService
    /// </summary>
    public interface INoteService
    {
        Task<List<Note>> GetNotes(PaginationFilter paginationFilter = null);

        Task<Note> GetNoteById(Guid noteId);

        Task<bool> UpdateNote(Note updateNote);

        Task<bool> DeleteNote(Guid noteId);

        Task<bool> CreateNote(Note note);
    }
}
