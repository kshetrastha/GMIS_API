using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Infrastructure.Persistence.Context;
using gmis.Application.Contracts.Persistence;
using gmis.Infrastructure.Repositories.LOF;
using gmis.Application.Contracts.Persistence.Industries;
using gmis.Infrastructure.Repositories.Industries;
using gmis.Infrastructure.Repositories.Notes;

namespace gmis.Infrastructure.Repositories.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private readonly IConfiguration _configuration;
        public RepositoryManager(RepositoryContext repositoryContext, IConfiguration configuration)
        {
            _repositoryContext = repositoryContext;
            _configuration = configuration;
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

        public IDbContextTransaction BeginTran()
        {
            return _repositoryContext.Database.BeginTransaction();
        }
        #region Line Of Business
        public ILineOfBusinessRepository LineOfBusinessRepository => new LineOfBusinessRepository(_configuration, _repositoryContext);


        #endregion
        public IIndustriesRepository IndustriesRepository =>  new IndustryRepository(_configuration, _repositoryContext);

        public INotesRepository NotesRepository =>  new NotesRepository(_configuration,_repositoryContext);
    }
}
