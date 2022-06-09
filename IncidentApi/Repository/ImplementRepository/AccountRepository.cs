using Domain;
using Domain.Entities;
using IncidentApi.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IncidentApi.Repository.ImplementRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;       

        public AccountRepository(AppDbContext context)
        {
            _context = context;         
            
        }

        public Account CreateAccount(Account account)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account),message:"No data to add");
            }                 
            _context.Accounts.Add(account);
            return account;
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();      
                        
        }
    }
}
