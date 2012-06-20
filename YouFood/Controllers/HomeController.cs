using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Domain.Model;
using YouFood.Services;

namespace YouFood.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            MenuService menuService = new MenuService();
            Specialty specialty = menuService.GetCurrentSpecialty();
            return View(specialty);
        }
    }
}
