using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class CartLine : Entity<int>
    {
        public int Quantity { get; set; }

        public int DishId { get; set; }
        public virtual Dish Dish { get; set; }

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
