using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Domain;

namespace TestTask.Data
{
    public class NoteStorage : INoteStorage
    {
        private readonly DataContext _dataContext;

        public NoteStorage(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task DeleteNote(string id)
        {
            var note = await _dataContext.NoteEntities.SingleOrDefaultAsync(x => x.Id.ToString() == id);

            _dataContext.NoteEntities.Remove(note);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<Note> GetNoteById(string id)
        {
            var note = await _dataContext.NoteEntities.SingleOrDefaultAsync(x => x.Id.ToString() == id);
            return note == null? null : ToDomain(note);
        }

        public async Task<IEnumerable<Note>> GetNotes()
        {
            var notes = await _dataContext.NoteEntities.ToListAsync();
            return notes.Select(ToDomain).ToList();
        }

        public async Task UpdateNote(string id, Note updateNote)
        {
            var noteEntity = await _dataContext.NoteEntities.SingleOrDefaultAsync(x => x.Id.ToString() == id);

            noteEntity.Content = updateNote.Content;

            _dataContext.NoteEntities.Update(noteEntity);
            await _dataContext.SaveChangesAsync();
        }

        private static Note ToDomain(NoteEntity entity)
        {
            return new Note(
                entity.Id.ToString(),
                entity.Content);
        }

        public async Task<string> InsertAsync(Note note)
        {
            var noteEntity = new NoteEntity
            {
                Content = note.Content
            };

            await _dataContext.AddAsync(noteEntity);
            await _dataContext.SaveChangesAsync();

            return noteEntity.Id.ToString();
        }
    }
}
