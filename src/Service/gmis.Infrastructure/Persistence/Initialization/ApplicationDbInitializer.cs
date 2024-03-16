using Microsoft.EntityFrameworkCore;
using gmis.Infrastructure.Persistence.Context;

namespace gmis.Infrastructure.Persistence.Initialization
{
    internal class ApplicationDbInitializer
    {
        private readonly RepositoryContext _dbContext;
        public ApplicationDbInitializer(RepositoryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task InitializeAsync(CancellationToken cancellationToken)
        {
            if (_dbContext.Database.GetMigrations().Any())
            {
                if ((await _dbContext.Database.GetPendingMigrationsAsync(cancellationToken)).Any())
                {
                    await _dbContext.Database.MigrateAsync(cancellationToken);
                }
            }
        }
    }
}
