using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Data;

namespace TestTask.Domain
{
    public class NoteService : INoteService
    {
        private readonly DataContext _context;

        public NoteService(DataContext context)
        {
            _context = context;
        }

        public async Task CreateNote(NoteEntity note)
        {
            var created = await _context.NoteEntities.AddAsync(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNote(Guid id)
        {
            var note = await _context.NoteEntities.SingleOrDefaultAsync(x => x.Id == id);

            _context.NoteEntities.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task<NoteEntity> GetNoteById(Guid id)
        {
            return await _context.NoteEntities.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<NoteEntity>> GetNotes()
        {
            return await _context.NoteEntities.ToListAsync();
        }

        public async Task UpdateNote(Guid id, string content)
        {
            var note = await _context.NoteEntities.FirstOrDefaultAsync(x => x.Id == id);
            note.Note = content;

            _context.NoteEntities.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}
