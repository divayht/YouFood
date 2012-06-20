using System.Collections.Generic;
using YouFood.Domain.Model.Base;

namespace YouFood.Domain.Model
{
    public class Dish : Entity<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public string Image { get; set; }
        public double TimeToCook { get; set; }

        public DishType DishType { get; set; }


        public int DishTypeId
        {
            get { return (int) DishType; }
            set { DishType = (DishType) value; }
        }

        // Relationships

        public int SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }
    }

    public enum DishType : int
    {
        Starter = 1,
        MainDish = 2,
        Desert = 3
    }
}
