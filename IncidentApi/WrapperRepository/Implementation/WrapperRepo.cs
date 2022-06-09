using Domain;
using IncidentApi.Repository.Contracts;
using IncidentApi.Repository.ImplementRepository;
using IncidentApi.WrapperRepository.Contracts;

namespace IncidentApi.WrapperRepository.Implementation
{
    public class WrapperRepo : IWrapperRepo
    {
        private IContactRepository _repoContact;
        private IAccountRepository _repoAccount;
        private IIncidentRepository _repoIncident;
        private AppDbContext _dbContext;

        public WrapperRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IContactRepository Contact {
            get
            {
                if (_repoContact == null)
                {
                    _repoContact = new ContactRepository(_dbContext);
                }
                return _repoContact;
            }
        }

        public IAccountRepository Account
        {
            get
            {
                if (_repoAccount == null)
                {
                    _repoAccount = new AccountRepository(_dbContext);
                }
                return _repoAccount;
            }
        }
        public IIncidentRepository Incident
        {
            get
            {
                if (_repoIncident == null)
                {
                    _repoIncident = new IncidentRepository(_dbContext);
                }
                return _repoIncident;
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
