using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using YouFood.Domain.Model;
using YouFood.Helpers;
using YouFood.Models;
using YouFood.Services;
using YouFood.ViewModels;

namespace YouFood.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult LogOn()
        {
            if (this.User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Client");
            }

            var model = new LogOnViewModel();

            return View(model);
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            this.ClearCookie();

            return RedirectToAction("Index", "Client");
        }

        [HttpPost]
        public ActionResult LogOn(string username, string password, int zoneId, int tableId)
        {
            if (this.User.Identity.IsAuthenticated == true)
            {
                return RedirectToAction("Index", "Client");
            }

            UserService userService = new UserService();

            User user = userService.Get(username);

            if (user == null)
            {
                ModelState.AddModelError("", "Le nom est incorrect.");
                return View(new LogOnViewModel());
            }
            if (user.Password != password)
            {
                ModelState.AddModelError("", "Le mot de passe est incorrect.");
                return View(new LogOnViewModel());
            }

            var cookie = GenerateCookie(user, tableId);
            this.Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Client");
        }

        private HttpCookie GenerateCookie(User user, int tableId)
        {
            const int sessionDuration = 900;

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                1,
                user.Name,
                DateTime.Now,
                DateTime.Now.AddMinutes(sessionDuration),
                false,
                tableId.ToString());

            UpdateUserIdentity(ticket);
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            return cookie;
        }

        private void ClearCookie()
        {
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName))
            {
                HttpCookie cookie = this.ControllerContext.HttpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    this.ControllerContext.HttpContext.Response.Cookies.Add(cookie);
                }
            }
        }

        private void UpdateUserIdentity(FormsAuthenticationTicket ticket)
        {
            this.HttpContext.User = new GenericPrincipal(new ExtendedIdentity(ticket), null);
        }
    }


}
