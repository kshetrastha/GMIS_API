using gmis.Application.Common.Helper;
using gmis.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.LOB.Queries.GetPaginatedLOB
{
    public class GetLineOfBusinessPaginatedQuery :IRequest<ResponseModel<LineOfBusinessPaginatedDto>>
    {
        public string Keyword { get; set; }
        public PaginationSetting paginationSetting{ get; set; } = new PaginationSetting();
    }
}
