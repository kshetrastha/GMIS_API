using AutoMapper;
using gmis.Application.Features.Industries.Command.CreateIndustry;
using gmis.Application.Features.Industries.Command.UpdateIndustry;
using gmis.Application.Features.LOB.Command.CreateLineOfBusiness;
using gmis.Application.Features.LOB.Command.UpdateLineOfBusiness;
using gmis.Application.Features.LOF.Queries.GetAllListAsync.Model;
using gmis.Domain.Entities;
using gmis.Domain.Entities.Industry;
using gmis.Domain.Entities.Industry.DataTransferObjects;
using gmis.Domain.Entities.LineOfBusiness;
using gmis.Domain.Entities.LineOfBusiness.DataTransferObjects;

namespace gmis.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LineOfBusinessDtos, LineOfBusiness>().ReverseMap();
            CreateMap<LineOfBusinessModel, LineOfBusiness>().ReverseMap();
            CreateMap<CreateLineOfBusinessCommand, LineOfBusiness>().ReverseMap();
            CreateMap<UpdateLineOfBuisnessCommand, LineOfBusiness>().ReverseMap();

            CreateMap<IndustriesDto, Industry>().ReverseMap();
            CreateMap<CreateIndustryCommand, Industry>().ReverseMap();
            CreateMap<UpdateIndustryCommand, Industry>().ReverseMap();
            CreateMap<DeleteIndustryCommand, Industry>().ReverseMap();

        }

    }
}
