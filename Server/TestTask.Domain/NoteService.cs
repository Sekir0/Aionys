using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public class NoteService : INoteService
    {
        private readonly INoteStorage _noteStorage;

        public NoteService(INoteStorage noteStorage)
        {
            _noteStorage = noteStorage;
        }

        public async Task<(DomainResult, string)> CreateAsync(string content)
        {
            var note = new Note(default, content);

            var noteId = await _noteStorage.InsertAsync(note);

            return (DomainResult.Success(), noteId);
        }

        public async Task DeleteAsync(string id)
        {
            await _noteStorage.DeleteNote(id);
        }

        public async Task<Note> GetByIdAsync(string id)
        {
            return await _noteStorage.GetNoteById(id);
        }

        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return await _noteStorage.GetNotes();
        }

        public async Task<DomainResult> UpdateAsync(string id, string content)
        {
            var note = await _noteStorage.GetNoteById(id);

            if (note == null)
            {
                return DomainResult.Error("Note not found");
            }

            note.Update(content);
            await _noteStorage.UpdateNote(id, note);
            return DomainResult.Success();
        }
    }
}
