using gmis.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.Industries.Command.CreateIndustry
{
    public class CreateIndustryCommand :IRequest<ResponseModel<string>>
    {
        public string NaicsCode { get; set; } = null!;

        public string? NaicsTitle { get; set; }
    }
}
