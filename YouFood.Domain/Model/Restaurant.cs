using YouFood.Domain.Model.Base;
using System.Collections.Generic;

namespace YouFood.Domain.Model
{
    public class Restaurant : Entity<int>
    {
        public string Name { get; set; }

        // Relationships

        public int CorporateId { get; set; }
        public virtual Corporate Corporate { get; set; }
        public virtual IList<Zone> Zones { get; set; }
    }
}
