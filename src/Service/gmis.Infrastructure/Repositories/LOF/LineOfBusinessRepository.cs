using Dapper;
using gmis.Application.Contracts.Persistence;
using gmis.Application.Features.LOB.Queries.GetPaginatedLOB;
using gmis.Domain.Entities;
using gmis.Domain.Entities.LineOfBusiness;
using gmis.Domain.Entities.LineOfBusiness.DataTransferObjects;
using gmis.Infrastructure.Persistence.Context;
using gmis.Infrastructure.Persistence.OueryBuilders;
using gmis.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Abstractions;
using System.Data;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace gmis.Infrastructure.Repositories.LOF
{
    public class LineOfBusinessRepository : RepositoryBase<LineOfBusiness>, ILineOfBusinessRepository
    {
        public LineOfBusinessRepository(IConfiguration configuration, RepositoryContext repositoryContext) : base(configuration, repositoryContext)
        {
        }

        public async Task<List<LineOfBusiness>> GetAllAsync()
        {
            try
            {
                var response = await FindAll(false).ToListAsync();
                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<LineOfBusinessPaginatedDto> GetLobPaginatedAsync(GetLineOfBusinessPaginatedQuery model)
        {
            var data = new LineOfBusinessPaginatedDto() { PaginationSetting = model.paginationSetting };
            try
            {
                var ord = model.paginationSetting.OrderBy;
                if (string.IsNullOrWhiteSpace(ord))
                    ord = "LineOfBusinessId";
                var prms = CreateDynamicParameters();
                QueryBuilder builder = new QueryBuilder();
                builder.Columns = new string[]
                {
                    "ROW_NUMBER() OVER (ORDER BY " + ord + " " + (model.paginationSetting.OrderByAscending ? string.Empty : "DESC") + ") AS RowNum",
                    "*",
                };
                builder.Table = "LineOfBusiness";

                if (!string.IsNullOrWhiteSpace(model.Keyword))
                {
                    builder.Conditions.Add(new QueryCondition
                    {
                        Operation = Logic.AND,
                        Condition = "LineOfBusinessName LIKE @userName",
                    });
                    prms.Add("userName", model.Keyword + '%');
                }

                StringBuilder sql = new StringBuilder();
                sql.AppendLine(";WITH PAGED AS (");
                sql.AppendLine(builder.BuildQuery());
                sql.AppendLine(")");
                sql.AppendLine("SELECT * FROM PAGED WHERE RowNum BETWEEN @start_row AND @end_row;");
                sql.AppendLine(builder.BuildCountQuery());
                prms.Add("start_row", (model.paginationSetting.PageNum - 1) * model.paginationSetting.PageSize + 1);
                prms.Add("end_row", model.paginationSetting.PageNum * model.paginationSetting.PageSize);

                using (var connection = CreateConnection())
                {
                    var ds = await connection.QueryMultipleAsync(sql.ToString(), prms, commandType: CommandType.Text);
                    data.LineOfBusinessDtos = ds.Read<LineOfBusinessDtos>().ToList();
                    data.PaginationSetting.TotalRows = ds.Read<int>().Single();
                }
                return data;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
