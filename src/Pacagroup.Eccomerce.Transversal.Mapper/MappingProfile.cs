using AutoMapper;
using Pacagroup.Eccomerce.Domain.Entity;
using Pacagroup.Eccomerce.Application.DTO;

namespace Pacagroup.Eccomerce.Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //mapeo de customers a customersdto y viceversa.
            CreateMap<Customers, CustomersDTO>().ReverseMap();
            CreateMap<Users, UsersDto>().ReverseMap();

            //En caso que los campos no coincidan

            //CreateMap<Customers, CustomersDTO>().ReverseMap()
            //    .ForMember(destination => destination.CustomersId, source => source.MapFrom(src => src.CustomersId))
            //    .ForMember(destination => destination.CompanyName, source => source.MapFrom(src => src.CompanyName))
            //    .ForMember(destination => destination.ContactName, source => source.MapFrom(src => src.ContactName))
            //    .ForMember(destination => destination.ContactTitle, source => source.MapFrom(src => src.ContactTitle))
            //    .ForMember(destination => destination.Address, source => source.MapFrom(src => src.Address))
            //    .ForMember(destination => destination.City, source => source.MapFrom(src => src.City))
            //    .ForMember(destination => destination.Region, source => source.MapFrom(src => src.Region))
            //    .ForMember(destination => destination.PostalCode, source => source.MapFrom(src => src.PostalCode))
            //    .ForMember(destination => destination.Country, source => source.MapFrom(src => src.Country))
            //    .ForMember(destination => destination.Phone, source => source.MapFrom(src => src.Phone))
            //    .ForMember(destination => destination.Fax, source => source.MapFrom(src => src.Fax))
            //    .ReverseMap();
        }
    }
}