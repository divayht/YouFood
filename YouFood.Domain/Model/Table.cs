using System.Collections.Generic;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Table : Entity<int>
    {
        // Relationships

        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public virtual IList<User> Users { get; set; } 
    }
}
