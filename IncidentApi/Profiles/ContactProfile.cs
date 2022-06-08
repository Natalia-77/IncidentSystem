using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;

namespace IncidentApi.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {          
            CreateMap<CreateContactModel, Contact>();
            CreateMap<Contact, ItemContactModel>();
        }
    }
}
