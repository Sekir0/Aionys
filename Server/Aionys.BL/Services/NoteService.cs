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
        /// Удаление заметки
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>deleted - целочисленное значение, если > 0 - возвращает true</returns>
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
        /// Получение заметки по Id
        /// </summary>
        /// <param name="noteId"></param>
        /// <returns>Возвращает заметку по Id</returns>
        public async Task<Note> GetNoteById(Guid noteId)
        {
            return await _dataContext.Notes.SingleOrDefaultAsync(x => x.Id == noteId);
        }

        /// <summary>
        /// Получаем все заметки с бд
        /// </summary>
        /// <param name="paginationFilter">пагинатор</param>
        /// <returns>Может вернуть все заметки (100),
        /// либо можем задать параметры для пагинатора и вернуть
        /// определенную страницу и количество заметок</returns>
        public async Task<List<Note>> GetNotes(PaginationFilter paginationFilter)
        {
            if(paginationFilter == null)
            {
                return await _dataContext.Notes.ToListAsync();
            }

            var skip = (paginationFilter.PageNumber - 1) * paginationFilter.PageSize;

            return await _dataContext.Notes.Skip(skip).Take(paginationFilter.PageSize).ToListAsync();
        }

        /// <summary>
        /// Обновление заметок
        /// </summary>
        /// <param name="updateNote"></param>
        /// <returns>updated - целочисленный тип, если > 0 возвращает true</returns>
        public async Task<bool> UpdateNote(Note updateNote)
        {
            _dataContext.Notes.Update(updateNote);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        /// <summary>
        /// Создание новых заметок
        /// </summary>
        /// <param name="note">note name</param>
        /// <returns>created > 0 return true</returns>
        public async Task<bool> CreateNote(Note note)
        {
            await _dataContext.Notes.AddAsync(note);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }
    }
}
