using Domain.Entities;

namespace IncidentApi.Models
{
    public class ItemIncidentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
