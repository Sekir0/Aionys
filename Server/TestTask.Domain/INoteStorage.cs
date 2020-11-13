using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public interface INoteStorage
    {
        Task<IEnumerable<Note>> GetNotes();

        Task<Note> GetNoteById(string id);

        Task<string> InsertAsync(Note note);

        Task UpdateNote(string id, Note updateNote);

        Task DeleteNote(string id);
    }
}
