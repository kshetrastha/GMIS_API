using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Infrastructure.Persistence.Initialization
{
    internal class DatabaseInitializer : IDatabaseInitializer
    {
        private readonly DatabaseSettings _dbSettings;
        private readonly IServiceProvider _serviceProvider;
        public DatabaseInitializer(IOptions<DatabaseSettings> dbSettings, IServiceProvider serviceProvider)
        {
            _dbSettings = dbSettings.Value;
            _serviceProvider = serviceProvider;
        }
        public async Task InitializeDatabasesAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();

            await scope.ServiceProvider.GetRequiredService<ApplicationDbInitializer>()
                .InitializeAsync(cancellationToken);
        }
    }
}
