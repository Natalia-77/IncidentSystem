using AutoMapper;
using Domain;
using Domain.Entities;
using IncidentApi.Models;
using IncidentApi.Repository.Contracts;

namespace IncidentApi.Repository.ImplementRepository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _context;       

        public AccountRepository(AppDbContext context)
        {
            _context = context;          
            
        }

        public Account CreateAccount(ICollection<Contact> contact, Account account)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact),message:"No data to add");
            }


            var rr = new Account();
            rr.Name = account.Name;
            _context.Accounts.Add(rr);
            return rr;
        }

        public List<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }
    }
}
