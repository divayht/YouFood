using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YouFood.Data.Repositories;
using YouFood.Domain.Model;

namespace YouFood.Services
{
    public class RestaurantService
    {
        private readonly RestaurantRepository restaurantRepository;

        public RestaurantService()
        {
            restaurantRepository = new RestaurantRepository();
        }

        public Table GetTable(int id)
        {
            TableRepository tableRepository = new TableRepository();
            return tableRepository.Get(id);
        }

        public void GetWaiter(int tableId)
        {
            
        }

        public void AddDish(Dish dish)
        {
            DishRepository dishRepository = new DishRepository();
            dishRepository.Add(dish);
        }
    }
}
