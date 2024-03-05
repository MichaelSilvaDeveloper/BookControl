using Application.Models.InputModels;
using Application.Models.ViewModels;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
    public class BookLoanProfile : Profile
    {
        public BookLoanProfile()
        {
            CreateMap<BookLoan, BookLoanViewModel>();

            CreateMap<BookLoanInputModel, BookLoan>();
        }
    }
}