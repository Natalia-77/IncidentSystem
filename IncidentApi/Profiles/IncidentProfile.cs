using AutoMapper;
using Domain.Entities;
using IncidentApi.Models;

namespace IncidentApi.Profiles
{
    public class IncidentProfile :Profile
    {
        public IncidentProfile()
        {
            CreateMap<CreateIncidentModel, Incident>();
            CreateMap<ContactAddModel, Contact>();
            CreateMap<Incident, ItemIncidentModel>();
        }
    }
}
