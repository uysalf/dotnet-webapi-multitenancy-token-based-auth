using System;
using AutoMapper;
using Entity.Models;
using Entity.ModelsDtos;

namespace Business
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<CustomUser, UserDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap(); ;
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<CustomUser, UserForRegisterDto>().ReverseMap();
        }
    }
}
