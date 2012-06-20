using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YouFood.Domain.Model;
using YouFood.Models;
using YouFood.Services;
using YouFood.ViewModels;

namespace YouFood.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private readonly MenuService menuService = new MenuService();
        private readonly RestaurantService restaurantService = new RestaurantService();

        public ActionResult Index(Cart cart)
        {
            Menu menu = menuService.GetCurrentMenu();
            MenuViewModel model = new MenuViewModel(menu, cart);

            return View(model);
        }

        public ActionResult AddToCart(Cart cart, int dishId)
        {
            Dish dish = menuService.GetDish(dishId);

            if (dish != null)
            {
                cart.AddItem(dish, 1);
            }

            ViewData["message"] = "Un plat a été ajouté à votre commande.";
            return RedirectToAction("Index", "Client");
        }

        [HttpPost]
        public ActionResult Checkout(Cart cart)
        {
            if (cart.Lines.Any() == false)
            {
                ModelState.AddModelError("Cart", "Désolé, votre panier est vide.");
            }

            if (ModelState.IsValid)
            {
                double totalTimeToCook = cart.Lines.Sum(x => x.Dish.TimeToCook);
                int amount = (int) cart.Lines.Sum(x => x.Dish.Price);

                int tableId = GetTableId();

                Table table = restaurantService.GetTable(tableId);

                Order order = new Order()
                {
                    Table = table,
                    OrderState = OrderState.New,
                    CartLines = cart.Lines,
                    Price = cart.Lines.Sum(x => x.Dish.TimeToCook),
                    Date = DateTime.Now
                };

                OrderService orderService = new OrderService();
                orderService.AddOrder(order);

                this.HttpContext.Session.Clear();

                return View("Paypal", amount);

                //return View(totalTimeToCook);
            }
            return RedirectToAction("Index", "Client");
        }

        public ActionResult RemoveFromCart(Cart cart, int dishId)
        {
            Dish dish = menuService.GetDish(dishId);

            if (dish != null)
            {
                cart.RemoveLine(dish);
            }
            return RedirectToAction("Index", "Client");
        }

        public ActionResult Summary(Cart cart)
        {
            return View(cart);
        }

        public ActionResult CallWaiter()
        {
            int tableId = GetTableId();
            restaurantService.GetWaiter(tableId);

            ViewData["message"] = "Un serveur va venir vous aider dans les prochaine minutes";
            return RedirectToAction("Index");
        }

        private int GetTableId()
        {
            var cookie = HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            var authTicket = FormsAuthentication.Decrypt(cookie.Value);
            int tableId = Convert.ToInt32(authTicket.UserData);

            return tableId;
        }
    }
}
