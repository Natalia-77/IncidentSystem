using IncidentApi.Repository.Contracts;

namespace IncidentApi.WrapperRepository.Contracts
{
    public interface IWrapperRepo
    {
        IContactRepository Contact { get; }
        IAccountRepository Account { get; }
        void Save();
    }
}
