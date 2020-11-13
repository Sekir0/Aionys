using Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestTask.Domain
{
    public interface INoteService
    {
        Task<Note> GetByIdAsync(string id);

        Task<IEnumerable<Note>> GetNotesAsync();

        Task<(DomainResult, string)> CreateAsync(string content);

        Task<DomainResult> UpdateAsync(string id, string content);

        Task DeleteAsync(string id);
    }
}
