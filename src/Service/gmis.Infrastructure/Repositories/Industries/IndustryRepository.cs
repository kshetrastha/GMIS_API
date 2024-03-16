using gmis.Application.Contracts.Persistence.Industries;
using gmis.Application.Exceptions;
using gmis.Domain.Entities.Industry;
using gmis.Infrastructure.Persistence.Context;
using gmis.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace gmis.Infrastructure.Repositories.Industries
{
    public class IndustryRepository : RepositoryBase<Industry>, IIndustriesRepository
    {
        public IndustryRepository(IConfiguration configuration, RepositoryContext repositoryContext) : base(configuration, repositoryContext)
        {
        }

        public async Task<List<Industry>> GetAllAsync(bool trackChanges)
        {
            try
            {
                return await FindAll(trackChanges).ToListAsync();
            }
            catch (Exception ex)
            {

                throw new InternalServerException(500, "Unable to fetch data. Please try again.");
            }
        }

        public async Task<Industry> GetByIdAsync(int id, bool trackChanges)
        {
            try
            {
                return await FindByCondition(x => x.IndustryId == id, trackChanges).FirstOrDefaultAsync();

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
