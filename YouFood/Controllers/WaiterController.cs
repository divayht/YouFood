using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Services;
using YouFood.Domain.Model;

namespace YouFood.Controllers
{
    [Authorize]
    public class WaiterController : Controller
    {
        private readonly OrderService orderService;

        public WaiterController()
        {
            orderService = new OrderService();
        }

        public ActionResult Index()
        {
            List<Order> orders = orderService.GetReadyOrders();

            return View(orders);
        }

        [HttpPost]
        public ActionResult OrderIsServed(int orderId)
        {
            orderService.UpdateState(orderId, OrderState.Closed);
            return RedirectToAction("Index", "Waiter");
        }

    }
}
