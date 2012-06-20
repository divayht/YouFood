using System.Collections.Generic;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Order : Entity<int>
    {
        public double Price { get; set; }

        public OrderState OrderState { get; set; }
        public int OrderStateId
        {
            get { return (int)OrderState; }
            set { OrderState = (OrderState)value; }
        }

        // Relationships

        public int TableId { get; set; }
        public virtual Table Table { get; set; }

        public virtual IList<Dish> Dishes { get; set; }
    }

    public enum OrderState : int
    {
        New = 1,
        Cooking = 2,
        ReadyToServe = 3,
        Closed = 4,
        Cancelled = 5
    }
}
