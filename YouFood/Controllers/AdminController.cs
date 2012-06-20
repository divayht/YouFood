using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouFood.Domain.Model;
using YouFood.Services;
using YouFood.ViewModels;

namespace YouFood.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListOrders()
        {
            OrderService orderService = new OrderService();
            List<Order> orders = orderService.GetAllOrders();

            return View(orders);
        }

        public ActionResult ListDishes()
        {
            MenuService menuService = new MenuService();
            List<Dish> dishes = menuService.GetAllDishes();

            return View(dishes);
        }

        public ActionResult AddDish()
        {
            var model = new AddDishViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddDish(string name, string description, double price, double timeToCook, int specialtyId,
                                    int dishTypeId)
        {
            RestaurantService restaurantService = new RestaurantService();
            MenuService menuService = new MenuService();
            Specialty specialty = menuService.GetSpecialty(specialtyId);

            Dish dish = new Dish
                            {
                                Name = name,
                                Description = description,
                                Price = price,
                                TimeToCook = timeToCook,
                                Specialty = specialty,
                                DishTypeId = dishTypeId
                            };

            restaurantService.AddDish(dish);

            return RedirectToAction("ListDishes");
        }

        public ActionResult SetSpecialty()
        {
            var model = new SpecialtyViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult SetSpecialty(int specialtyId)
        {
            MenuService menuService = new MenuService();
            menuService.SetSpecialty(specialtyId);

            return RedirectToAction("Index");
        }

        public ActionResult AddSpecialty()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSpecialty(string name, string description, string image)
        {
            Specialty specialty = new Specialty
                                      {
                                          Name = name,
                                          Description = description,
                                          IsActive = false,
                                          Image = image
                                      };

            MenuService menuService = new MenuService();
            menuService.AddSpecialty(specialty);

            return RedirectToAction("ListDishes");
        }

        public ActionResult ListUsers()
        {
            UserService userService = new UserService();
            List<User> users = userService.GetAll();

            return View(users);
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name) == true || string.IsNullOrWhiteSpace(password) == true)
            {
                ModelState.AddModelError("", "Le nom et le mot de passe ne doivent pas être vides.");
                return View();
            }

            UserService userService = new UserService();

            User user = new User
            {
                Name = name,
                Password = password
            };

            userService.AddUser(user);

            return RedirectToAction("ListUsers");
        }
    }
}
