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
		private IMailService _mailService;
	
		public AccountController(IUserService userService, IMailService mailService)
		{
			this._userService = userService;
			this._mailService = mailService;
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
					Membership.CreateUser(user.Username, password, user.Email);
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

		public ActionResult ForgotPassword()
		{
			return View();
		}

		[HttpPost]
		public ActionResult ForgotPassword(string username)
		{
			MembershipUser user = Membership.GetUser(username);

			if (user != null)
			{
				_mailService.SendMail(user.Email, user.UserName, "change password", "Your new Password is: " + user.ResetPassword());
				Membership.UpdateUser(user);
			}

			return RedirectToAction("Login");
		}

		[Authorize]
		public ActionResult ChangePass()
		{

			return View();
		}

		[HttpPost]
		[Authorize]
		public ActionResult ChangePass(string oldpassword, string newpassword1, string newpassword2)
		{
			MembershipUser user = Membership.GetUser(this.User.Identity.Name);

			if (newpassword1 == newpassword2)
			{

				MembershipPasswordAttribute passcheck = new MembershipPasswordAttribute();

				if (passcheck.IsValid(newpassword1))
				{
					if (user.ChangePassword(oldpassword, newpassword1))
						return RedirectToAction("Index", "Home");
					else
						ModelState.AddModelError("", "Old pass wrong");
				}
				else
					ModelState.AddModelError("", "You need a stronger password");
			}
			else
				ModelState.AddModelError("", "New passwords dont match");

			return RedirectToAction("Index", "Home");
		}

		public ActionResult Logout()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}
    }
}
