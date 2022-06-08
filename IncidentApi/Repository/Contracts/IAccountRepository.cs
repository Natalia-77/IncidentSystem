using Domain.Entities;
using IncidentApi.Models;

namespace IncidentApi.Repository.Contracts
{
    public interface IAccountRepository
    {
        public List<Account> GetAllAccounts();
        public Account CreateAccount(ICollection<Contact> contact,Account account);
    }
}
