using ProductConfigurator.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProductConfigurator.WebUI.Models;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.WebUI.Controllers
{
    public class UserController : Controller
    {
        private IProductService _productService;

        public UserController(IProductService productService)
		{
			_productService = productService;
		}
        public ActionResult Index()
        {
            //Man måste vara inloggad
            return View();
        }

        public ActionResult ProductPartial()
        {
            //IEnumerable<ProductViewModel> model = _productService.GetAll().MapToList(new List<ProductViewModel>());
            IEnumerable<Product> products = _productService.GetAll();

            //AutoMapper.Mapper.CreateMap<Product, ProductViewModel>();
            IEnumerable<ProductViewModel> model = products.MapToList(new List<ProductViewModel>());

            return View(model);
        }

        public ActionResult CategoryPartial()
        {
            var product = _productService.GetById(1);
            var categories = product.Category;

            Category cat = new Category { Name = "TEST" };

            //_productService.SaveCategory(cat);


            return View();
        }

    }
}
