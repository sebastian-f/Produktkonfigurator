using ProductConfigurator.Services.Interface;
using ProductConfigurator.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductConfigurator.WebUI.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

		private IProductService _productService;

		public AdminController(IProductService productService)
		{
			this._productService = productService;
		}

        public ActionResult Index()
        {
            return View();
        }

		public ActionResult ProductPartial()
		{
			var productViewModel = _productService.GetAll().MapTo(new List<ProductViewModel>());

			productViewModel.Add(new ProductViewModel() { Id = 1, Name = "prod" });
			productViewModel.Add(new ProductViewModel() { Id = 2, Name = "prod2" });
			return View(productViewModel);
		}

		public ActionResult AddProduct(string name)
		{
			var product = new ProductViewModel() { Name = name };

			_productService.SaveProduct(product.MapTo(new Domain.Model.Product()));
			return View();
		}

		public ActionResult CategoryPartial(int productId)
		{
			//var productViewModel = _productService.GetById(productId).MapTo(new List<CategoryViewModel>());

			var productViewModel = new List<CategoryViewModel>();
			productViewModel.Add(new CategoryViewModel() { Id = 1, Name = "category" });
			return View(productViewModel);
		}


    }
}
