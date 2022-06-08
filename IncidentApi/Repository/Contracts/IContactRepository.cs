using Domain.Entities;

namespace IncidentApi.Repository.Contracts
{
    public interface IContactRepository
    {
        public List<Contact> GetAll();
        Contact? GetByEmail(string email);
        void Create(Contact contact);
      
    }
}
