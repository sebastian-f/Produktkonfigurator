using ProductConfigurator.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using ProductConfigurator.WebUI.Models;
using ProductConfigurator.Domain.Model;
using ProductConfigurator.WebUI.Methods.User;


namespace ProductConfigurator.WebUI.Controllers
{

	[Authorize]
    public class UserController : Controller
    {
        private IProductService _productService;
        private IOrderService _orderService;
        public UserMethods _methods;

        public UserController(IProductService productService, IOrderService orderService, UserMethods methods)
        {
            _methods = methods;
            _productService = productService;
            _orderService = orderService;
        }
        public ActionResult Index()
        {
            //Man måste vara inloggad
            return View();
        }


        public ActionResult OrderConfirmation(FormCollection form)
        {
            //Skapa ORDERVIEWMODEL från formcollection
            Product product = _productService.GetById(int.Parse(form[0]));
            OrderViewModel model = new OrderViewModel();
            model.ProductName = product.Name;
            model.ProductId = product.Id;
            model.CategoryParts = new List<OrderCategoryPartViewModel>();
            //var productId = form[0];
            //var productName = form.Keys[0];
            for (int i = 1; i < form.AllKeys.Count(); i++)
            {
                Part part = _productService.GetPartById(int.Parse(form[i]));
                OrderCategoryPartViewModel item = new OrderCategoryPartViewModel();
                item.CategoryName = _productService.GetCategory(int.Parse(form.Keys[i])).Name;
                item.PartName = part.Name;
                item.PartPrice = part.Price;
                item.PartCode = part.Code;
                item.PartId = part.Id;
                item.DeliveryDate = part.DeliveryDate;
                model.CategoryParts.Add(item);
            }
            model.TotalPrice = model.CategoryParts.Sum(x => x.PartPrice);
            model.DeliveryDate = model.CategoryParts.Max(x => x.DeliveryDate);
            return View(model);

        }

        public ActionResult CreateOrder(OrderViewModel model)
        {
            //Skapa order
            _methods.CreateOrder(model);
            return View();
        }

        public ActionResult ProductPartial()
        {
            IEnumerable<Product> products = _productService.GetAll();
            IEnumerable<ProductViewModel> model = products.MapToList(new List<ProductViewModel>());

            return View(model);
        }

        public ActionResult CategoryPartial()
        {
            //List<CategoryPartsViewModel> list = new List<CategoryPartsViewModel>();
            return View();
        }

        [HttpPost]
        public ActionResult CategoryPartial(int productId)
        {
            //HÄMTA ALLA KATEGORIER SOM HÖR TILL DENNA PRODUKTID
            var product = _productService.GetById(productId);
            IEnumerable<CategoryPartsViewModel> model = product.Category.MapToList(new List<CategoryPartsViewModel>());
            return View(model);
        }

        public ActionResult GetRelationsPartPartial(int categoryId, string partIdsString)
        {
			//Hämta relationer och uppdatera selectboxarna i Index.cshtml
            CategoryPartsViewModel model = new CategoryPartsViewModel();
            model = _methods.GetUpdatedModelForSelectList(categoryId, partIdsString);

			
			return View(model);
        }

    }
}
