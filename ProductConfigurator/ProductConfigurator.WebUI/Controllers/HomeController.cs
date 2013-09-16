using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Interface;
using ProductConfigurator.WebUI.Models;

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
            //TEST
            ProductViewModel product = new ProductViewModel{Name="Båt"};
            _productService.SaveProduct(product.ToDomainModel());

            return View();
        }

    }
}
