using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Services;
using YouFood.Domain.Model;
using YouFood.ViewModels;

namespace YouFood.Controllers
{
    [Authorize]
    public class KitchenController : Controller
    {
        private readonly OrderService orderService;

        public KitchenController()
        {
            orderService = new OrderService();
        }

        public ActionResult Index()
        {
            List<Order> orders = orderService.GetPendingOrders();
            var model = new KitchenViewModel(orders);

            return View(model);
        }

        [HttpPost]
        public ActionResult DishIsCooking(int orderId)
        {
            orderService.UpdateState(orderId, OrderState.Cooking);
            return RedirectToAction("Index", "Kitchen");
        }

        [HttpPost]
        public ActionResult DishIsReadyToServe(int orderId)
        {
            orderService.UpdateState(orderId, OrderState.ReadyToServe);
            return RedirectToAction("Index", "Kitchen");
        }
    }
}
