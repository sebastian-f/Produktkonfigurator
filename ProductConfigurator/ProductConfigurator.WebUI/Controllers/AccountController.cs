using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.WebUI.Models;
using System.Web.Security;
using ProductConfigurator.Services.Interface;

namespace ProductConfigurator.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

		private IUserService _userService;
	
		public AccountController(IUserService userService)
		{
			this._userService = userService;
		}

		[HttpGet]
        public ActionResult Login()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Login(string username, string password)
		{
			try
			{
				if (Membership.ValidateUser(username, password))
				{
					FormsAuthentication.SetAuthCookie(username, false);
					return RedirectToAction("Index", "Home");
				}
			}
			catch (Exception)
			{

				ModelState.AddModelError(string.Empty, "Failed login");
			}
			return View();
		}

		[HttpGet]
		public ActionResult CreateAccount()
		{
			return View();
		}

		[HttpPost]
		public ActionResult CreateAccount(UserViewModel user, string password)
		{
			//if (ModelState.IsValid) TODO: Hur funkar modelstate här?
			//{
				try
				{
					Membership.CreateUser(user.Username, password);
					_userService.CreateUser(user.MapTo(new Domain.Model.User()));
					return RedirectToAction("Index", "Home");
				}
				catch (Exception ex)
				{
					throw new NullReferenceException("", ex);
				}
			//}
			return View(user);
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
    }
}
