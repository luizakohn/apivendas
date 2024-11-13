using AutoMapper;
using MyCrudApp.Application.DTOs;
using MyCrudApp.Core.Entities;

namespace MyCrudApp.Application.Mappings
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper() 
        {
            CreateMap<Customer, UpdateCustomerDTO>();
            CreateMap<UpdateCustomerDTO, Customer>();
            CreateMap<CreateCustomerDTO, Customer>();
        }
    }
}
