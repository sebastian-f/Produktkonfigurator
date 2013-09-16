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

        public ActionResult Login()
        {
			var u = new UserViewModel();

			var e = u.ToDomainModel();
            return View();
        }

		public ActionResult Login(string username, string password)
		{
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
			//if (ModelState.IsValid)
			//{
				try
				{
					Membership.CreateUser(user.Username, password);
					_userService.CreateUser(user.ToDomainModel());
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
			return View();
		}
    }
}
