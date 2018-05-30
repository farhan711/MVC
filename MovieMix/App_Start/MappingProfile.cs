using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieMix.Models;
using MovieMix.Dtos;
namespace MovieMix.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            Mapper.CreateMap<CustomerDTO, Customer>();
           
        }
    }

    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            //Mapper.CreateMap<Customer, CustomerDTO>().ReverseMap();
            Mapper.CreateMap<Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(s => s.Name + "XYZ"));                
                
        }
    }
}