using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;

namespace IncidentApi.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {

            CreateMap<CreateAccountModel, Account>()
               .ForMember(dest => dest.Name, opt => opt.MapFrom(x => x.Name))
               .ForMember(dest => dest.IncidentNameKey, opt => opt.MapFrom(x => x.IncidentNameKey))
               .ForMember(dest => dest.Contacts, opt => opt.Ignore());
             
            CreateMap<Account, ItemAccountModel>();
        }
    }
}
