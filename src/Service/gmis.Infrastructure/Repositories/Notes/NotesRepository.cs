using gmis.Application.Contracts.Persistence;
using gmis.Domain.Entities.Notes;
using gmis.Infrastructure.Persistence.Context;
using gmis.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Infrastructure.Repositories.Notes
{
    public class NotesRepository : RepositoryBase<Note>, INotesRepository
    {
        public NotesRepository(IConfiguration configuration, RepositoryContext repositoryContext) : base(configuration, repositoryContext)
        {
        }

        public async Task<List<Note>> GetAllAsync(bool trackAsync)
        {
            try
            {
                return await FindAll(trackAsync).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Note> GetByIdAsync(int id, bool trackAsync)
        {
            try
            {
                return await FindByCondition(x=>x.NoteId==id,trackAsync).FirstOrDefaultAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
