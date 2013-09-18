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
            IEnumerable<ProductViewModel> model = _productService.GetAll().ToViewModel();
            
            return View(model);
        }

        public ActionResult CategoryPartial()
        {
            return View();
        }

    }
}
