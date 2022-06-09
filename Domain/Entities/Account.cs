using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Contact>? Contacts { get; set; }
        [JsonIgnore]
        public string? IncidentNameKey { get; set; }
        [JsonIgnore]
        public virtual Incident? Incident { get; set; }
    }
}
