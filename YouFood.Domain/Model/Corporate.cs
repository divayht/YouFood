using YouFood.Domain.Model.Base;
using System.Collections.Generic;

namespace YouFood.Domain.Model
{
    public class Corporate : Entity<int>
    {
        public string Name { get; set; }

        // Relationships

        public virtual IList<Restaurant> Restaurants { get; set; }
    }
}
