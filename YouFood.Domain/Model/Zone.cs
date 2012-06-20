using System.Collections.Generic;

using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Zone : Entity<int>
    {
        public string Name { get; set; }

        // Relationships

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
        public virtual IList<Table> Tables { get; set; } 
    }
}
