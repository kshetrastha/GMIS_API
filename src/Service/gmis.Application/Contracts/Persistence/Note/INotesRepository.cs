using gmis.Domain.Entities.Notes;
using gmis.Domain.Entities.Notes.DataTransferObjects;

namespace gmis.Application.Contracts.Persistence
{
    public interface INotesRepository
    {
        void Create(Note model);
        void Update(Note model);
        Task<List<Note>> GetAllAsync(bool trackAsync);
        Task<Note> GetByIdAsync(int id, bool trackAsync);
    }
}
