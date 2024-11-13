using AutoMapper;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Core.Entities;

namespace MyCrudApp.Application.Mappings
{
    public class ItemsMapper : Profile
    {
        public ItemsMapper() 
        { 
            CreateMap<UpdateItemDTO, Item>();
            CreateMap<CreateItemDTO, Item>();
        }
    }
}
