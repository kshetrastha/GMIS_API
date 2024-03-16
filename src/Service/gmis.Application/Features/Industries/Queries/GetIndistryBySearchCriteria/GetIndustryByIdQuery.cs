using gmis.Application.Common.Model;
using gmis.Domain.Entities.Industry.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.Industries.Queries.GetIndistryById
{
    public class GetIndustryByIdQuery :IRequest<ResponseModel<IndustriesDto>>
    {
        public int IndustryId { get; set; }
        public GetIndustryByIdQuery(int id)
        {
            this.IndustryId = id;
        }
    }
}
