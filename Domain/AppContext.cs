using Domain.Entities;
using Domain.ModelBuilderconfig;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class AppContext :DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) :
           base(options)
        {

        }

        public virtual DbSet<Contact> Contacts => Set<Contact>();
        public virtual DbSet<Account> Accounts => Set<Account>();
        public virtual DbSet<Incident> Incidents => Set<Incident>();

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder);
            modelbuilder.ApplyConfiguration(new ContactConfig());
            modelbuilder.ApplyConfiguration(new AccountConfig());
            modelbuilder.ApplyConfiguration(new IncidentConfig());

        }

    }
}