using Domain.Entities;

namespace IncidentApi.Models
{
    public class ItemAccountModel
    {       
        public string Name { get; set; }
        public List<Contact>? Contacts { get; set; }
        public string? IncidentNameKey { get; set; }
       
    }
}
