using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Table : Entity<int>
    {
        // Relationships

        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }
    }
}
