using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Services;
using YouFood.Domain.Model;

namespace YouFood.Controllers
{
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

    }
}
