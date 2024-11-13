using AutoMapper;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Core.Entities;

namespace MyCrudApp.Application.Mappings
{
    public class SalesMapper : Profile
    {
        public SalesMapper() 
        {
            CreateMap<CreateSaleDTO, Sale>();
            CreateMap<UpdateSaleDTO, Sale>()
                .ForMember(dest => dest.Items, opt => opt.Ignore());
        }
    }
}
