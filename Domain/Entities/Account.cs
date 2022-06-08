using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Contact>? Contacts { get; set; }
        public string? IncidentNameKey { get; set; }
        public virtual Incident? Incident { get; set; }
    }
}
