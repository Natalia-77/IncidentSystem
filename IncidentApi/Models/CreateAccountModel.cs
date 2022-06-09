namespace IncidentApi.Models
{
    public class CreateAccountModel
    {
        public string? Name { get; set; }

        public List<ContactAddModel> Contacts { get; set; }
        
        
    }

    public class ContactAddModel
    {        
        public string Email { get; set; }
    }
}
