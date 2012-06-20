using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Services;
using YouFood.Domain.Model;

namespace YouFood.Controllers
{
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

            return View(orders);
        }

        public ActionResult OrderStateChanged(List<Order> orders)
        {
            return null;
        }

    }
}
