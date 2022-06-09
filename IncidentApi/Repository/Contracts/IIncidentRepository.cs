using Domain.Entities;

namespace IncidentApi.Repository.Contracts
{
    public interface IIncidentRepository
    {
        public List<Incident> GetAllAccounts();
        public Incident CreateIncident(Incident incident);
    }
}
