using gmis.Application.Common.Model;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gmis.Application.Features.LOB.Command.CreateLineOfBusiness
{
    public class CreateLineOfBusinessCommand : IRequest<ResponseModel<string>>
    {
        public string LineOfBusinessName { get; set; } = null!;
    }
}
