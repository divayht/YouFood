using System.Collections.Generic;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Specialty : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        // Relationships

        public virtual IList<Dish> Dishes { get; set; }
    }
}
