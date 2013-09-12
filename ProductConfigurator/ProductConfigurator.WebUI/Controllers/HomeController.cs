using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Infrastructure.Repository;

namespace ProductConfigurator.WebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/

		private IProductRepository _productRepo;
	
		public HomeController(IProductRepository productRepo)
		{
			this._productRepo = productRepo;
		}

        public ActionResult Index()
        {
            return View();
        }

    }
}
