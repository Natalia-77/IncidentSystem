using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;

namespace IncidentApi.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {

            CreateMap<CreateAccountModel, Account>(); 
            CreateMap<ContactAddModel, Contact>();    
            CreateMap<Account, ItemAccountModel>();
        }
    }
}
