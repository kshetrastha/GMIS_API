using gmis.Application.Common.Helper;
using gmis.Domain.Entities.LineOfBusiness.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.LOB.Queries.GetPaginatedLOB
{
    public class LineOfBusinessPaginatedDto
    {
        public PaginationSetting PaginationSetting { get; set; } = new PaginationSetting();
        public List<LineOfBusinessDtos> LineOfBusinessDtos { get; set; } = new List<LineOfBusinessDtos> { new LineOfBusinessDtos() };
    }
}
