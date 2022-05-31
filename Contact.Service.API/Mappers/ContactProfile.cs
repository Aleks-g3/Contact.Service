using AutoMapper;
using Contact.Service.API.Entities;
using Contact.Service.Core.Models;

namespace Contact.Service.API.Mappers
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<RegisterUserDTO, User>();
            CreateMap<LoginUserDTO, LoginUser>();
            CreateMap<ContactDTO, ContactEntity>()
                .ForMember(m=>m.Category,m=>m.MapFrom(c=>c.Category));

            CreateMap<ContactEntity, SimpleContactDTO>();
            CreateMap<ContactEntity, ContactDTO>();
        }
    }
}
