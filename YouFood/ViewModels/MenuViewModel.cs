using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using YouFood.Domain.Model;
using YouFood.Models;

namespace YouFood.ViewModels
{
    public class MenuViewModel
    {
        public List<CartLine> Starters { get; private set; }
        public List<CartLine> MainDishes { get; private set; }
        public List<CartLine> Deserts { get; private set; }

        public MenuViewModel(Menu menu, Cart cart)
        {
            List<CartLine> tempLines = new List<CartLine>();

            foreach (var dish in menu.Dishes)
            {
                CartLine line = new CartLine() {Dish = dish};

                if (cart.Contains(dish))
                {
                    line.Quantity = cart.Get(dish).Quantity;
                }

                tempLines.Add(line);
            }

            Starters = tempLines
                .Where(x => x.Dish.DishType == DishType.Starter)
                .ToList();

            MainDishes = tempLines
                .Where(x => x.Dish.DishType == DishType.MainDish)
                .ToList();

            Deserts = tempLines
                .Where(x => x.Dish.DishType == DishType.Desert)
                .ToList();
        }
    }
}