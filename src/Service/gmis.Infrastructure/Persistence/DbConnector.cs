using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using gmis.Infrastructure.Persistence.Context;
using System.Data;
using gmis.Infrastructure.Converter;

namespace gmis.Infrastructure.Persistence
{
    public class DbConnector
    {
        private readonly IConfiguration _configuration;
        private readonly RepositoryContext _repositoryContext;
        public DbConnector(IConfiguration configuration, RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            var databaseSettings = _configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
            string? rootConnectionString = databaseSettings.ConnectionString;
            SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
            SqlMapper.AddTypeHandler(new SqlTimeOnlyTypeHandler());
            return new SqlConnection(rootConnectionString);
        }
        public RepositoryContext RepositoryContext { get { return _repositoryContext; } }

        public static DynamicParameters CreateDynamicParameters()
        {
            return new DynamicParameters();
        }
    }
}
