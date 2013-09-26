using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Interface;
using ProductConfigurator.WebUI.Models;
using System.Web.Security;

namespace ProductConfigurator.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

		private IProductService _productService;
	
		public HomeController(IProductService productService)
		{
			this._productService = productService;
		}


        public ActionResult Index()
        {
			if (User.IsInRole("Admin"))
				return RedirectToAction("Index", "Admin");
			else if (User.Identity.IsAuthenticated)
				return RedirectToAction("Index", "User");
			else
				return View();
        }
    }
}
