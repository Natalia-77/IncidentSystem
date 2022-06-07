using Domain.Entities;

namespace IncidentApi.Repository.Contracts
{
    public interface IContactRepository
    {
        Task<IEnumerable<Contact>> GetAll();
        Task<Contact?> GetByEmail(string email);
        Task Create(Contact contact);
        Task Save();
    }
}
