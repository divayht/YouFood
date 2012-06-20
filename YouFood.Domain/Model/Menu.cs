using System.Collections.Generic;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Menu : Entity<int>
    {
        public string Name { get; set; }

        // RelationShips

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public virtual List<Dish> Dishes { get; set; }
    }
}
