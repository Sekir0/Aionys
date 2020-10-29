using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Domain
{
    public interface INoteService
    {
        Task<List<NoteEntity>> GetNotes();

        Task<NoteEntity> GetNoteById(Guid id);

        Task CreateNote(NoteEntity note);

        Task UpdateNote(Guid id, string content);

        Task DeleteNote(Guid id);
    }
}
