using gmis.Domain.Entities.Industry;

namespace gmis.Application.Contracts.Persistence.Industries
{
    public interface IIndustriesRepository
    {
        void Create(Industry model);
        void Update(Industry model);
        Task<List<Industry>> GetAllAsync( bool trackChanges);
        Task<Industry> GetByIdAsync(int id, bool trackChanges);
        
    }
}
