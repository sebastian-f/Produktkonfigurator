using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Repository;
using ProductConfigurator.Services.Interface;

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
            return View();
        }

    }
}
