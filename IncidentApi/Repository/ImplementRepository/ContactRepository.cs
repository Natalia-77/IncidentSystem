using Domain;
using Domain.Entities;
using IncidentApi.Repository.Contracts;

namespace IncidentApi.Repository.ImplementRepository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _context;

        public ContactRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Create (Contact contact)
        {
            if (contact == null)
            {
                throw new ArgumentNullException(nameof(contact));
            }

            _context.Contacts.Add(contact);
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

      
        public Contact? GetByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException(nameof(email), message: "Email must be not null");
            }
            return  _context.Contacts!.FirstOrDefault(c => c.Email == email);
        }
               

    }
}
