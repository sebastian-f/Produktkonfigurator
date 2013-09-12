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
		private IProductRepository _productRepo;

        //
        // GET: /Home/
		public HomeController() : this(new ProductRepository()) { }

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
