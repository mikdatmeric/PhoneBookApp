using AutoMapper;
using ContactService.Application.DTOs;
using ContactService.Domain.Entities;
using static ContactService.Domain.Enums.Enums;

namespace ContactService.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Person <-> PersonDto
            CreateMap<Person, PersonDto>().ReverseMap();

            // Person <-> PersonDetailDto
            CreateMap<Person, PersonDetailDto>().ReverseMap();

            // ContactInfo <-> ContactInfoDto
            CreateMap<ContactInfo, ContactInfoDto>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<ContactType>(src.Type)));

            // CreatePersonCommandDto -> Person
            CreateMap<CreatePersonCommandDto, Person>();

            // UpdatePersonCommandDto -> Person
            CreateMap<UpdatePersonCommandDto, Person>();

            // CreateContactInfoCommandDto -> ContactInfo
            CreateMap<CreateContactInfoCommandDto, ContactInfo>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<ContactType>(src.Type)));

            // UpdateContactInfoCommandDto -> ContactInfo
            CreateMap<UpdateContactInfoCommandDto, ContactInfo>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<ContactType>(src.Type)));
        }
    }
}
