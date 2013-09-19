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

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            Product product = _productService.GetById(int.Parse(form[0]));
            OrderViewModel model = new OrderViewModel();
            model.ProductName = product.Name;
            //var productId = form[0];
            //var productName = form.Keys[0];
            for (int i = 1; i < form.AllKeys.Count(); i++)
            {
                
                var partId = form[i];
            }

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
            //List<CategoryPartsViewModel> list = new List<CategoryPartsViewModel>();
            return View();
        }

        [HttpPost]
        public ActionResult CategoryPartial(int productId = 0)
        {
            //HÄMTA ALLA KATEGORIER SOM HÖR TILL DENNA PRODUKTID
            var product = _productService.GetById(productId);
            IEnumerable<CategoryPartsViewModel> model = product.Category.MapToList(new List<CategoryPartsViewModel>());
            return View(model);
        }

    }
}
