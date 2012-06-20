using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Services;
using YouFood.Domain.Model;

namespace YouFood.Controllers
{
    public class ClientController : Controller
    {
        private readonly MenuService menuService;

        public ClientController()
        {
            menuService = new MenuService();
        }

        public ActionResult Index()
        {
            Menu menu = menuService.GetCurrentMenu();

            return View(menu);
        }

        [HttpPost]
        public ActionResult NewOrder(/*int tableId,*/ List<Dish> dishes)
        {
            double totalTimeToCook = dishes.Sum(dish => dish.TimeToCook);

            double totalPrice = dishes.Sum(dish => dish.Price);

            Order order = new Order()
            {
                TableId = 1,
                OrderState = OrderState.New,
                Dishes = dishes,
                Price = totalPrice
            };

            OrderService orderService = new OrderService();
            orderService.AddOrder(order);

            return View(totalTimeToCook);
        }
    }
}
