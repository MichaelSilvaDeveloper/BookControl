using Application.Models.InputModels;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerViewModel>();
            CreateMap<CustomerInputModel, Customer>();
        }
    }
}