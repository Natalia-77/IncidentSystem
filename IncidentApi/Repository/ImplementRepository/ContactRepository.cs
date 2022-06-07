using Domain;
using Domain.Entities;
using IncidentApi.Repository.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IncidentApi.Repository.ImplementRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            await _context.Contacts!.AddAsync(contact);
        }

        public async Task<IEnumerable<Contact>> GetAll()
        {
            return await _context.Contacts!.ToListAsync();
        }

        public Task<Contact?> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
