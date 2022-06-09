using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Incident
    {
      
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore]
        public ICollection<Account> Accounts { get; set; }
    }
}
