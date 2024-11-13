using AutoMapper;
using MyCrudApp.Core.Entities;
using MyCrudApp.Presentation.ViewModels;

namespace MyCrudApp.Presentation.Mappings
{
    public class SalesMapperViewModel : Profile 
    {
        public SalesMapperViewModel() 
        {
            CreateMap<Sale, GetAllSalesViewModel>()
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                .ForMember(dest => dest.TotalPrice, opt => opt.MapFrom(src => Math.Round(src.Items.Sum(i => i.Quantity * i.Price), 2)))
                .ForMember(dest => dest.TotalItems, opt => opt.MapFrom(src => src.Items.Sum(i => i.Quantity)));
            CreateMap<Sale, GetSalesByIdViewModel>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Customer.Id));
        }
        
    }
}
