
using IncidentApi.Repository.Contracts;

namespace IncidentApi.WrapperRepository.Contracts
{
    public interface IWrapperRepo
    {
        IContactRepository Contact { get; }
        IAccountRepository Account { get; }
        IIncidentRepository Incident { get; }
        void Save();
    }
}
