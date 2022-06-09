using Domain;
using Domain.Entities;
using IncidentApi.Repository.Contracts;

namespace IncidentApi.Repository.ImplementRepository
{
    public class IncidentRepository : IIncidentRepository
    {
        private readonly AppDbContext _context;
        public IncidentRepository(AppDbContext context)
        {
            _context = context;
        }
        public Incident CreateIncident(Incident incident)
        {
            if (incident == null)
            {
                throw new ArgumentNullException(nameof(incident), message: "No data to add");
            }
            _context.Incidents.Add(incident);
            return incident;
        }

        public List<Incident> GetAllAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
