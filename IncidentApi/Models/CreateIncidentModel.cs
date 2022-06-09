namespace IncidentApi.Models
{
    public class CreateIncidentModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public AccountAddModel AccountAddModels { get; set; }
    }

    public class AccountAddModel
    {
        public string Name { get; set; }
    }
}
