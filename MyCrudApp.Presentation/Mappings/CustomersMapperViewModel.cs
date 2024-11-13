using AutoMapper;
using MyCrudApp.Core.Entities;
using MyCrudApp.Presentation.ViewModels;

namespace MyCrudApp.Presentation.Mappings
{
    public class CustomersMapperViewModel : Profile 
    {
        public CustomersMapperViewModel() 
        {
            CreateMap<Customer, CustomerComboViewModel>();
        }
    }
}
