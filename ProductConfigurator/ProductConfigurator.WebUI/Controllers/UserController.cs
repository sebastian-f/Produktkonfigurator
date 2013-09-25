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
        private IOrderService _orderService;

        public UserController(IProductService productService, IOrderService orderService)
		{
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
                item.CategoryName = form.Keys[i];
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
            Order order = new Order();
            order.Price = model.TotalPrice;
            List<Part> partList = new List<Part>();
            order.DeliveryDate = model.DeliveryDate;
            
            foreach (var item in model.CategoryParts)
            {
                Part p = _productService.GetPartById(item.PartId);
                
                partList.Add(p);
            }
            _orderService.Save(order, partList);
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
        public ActionResult CategoryPartial(int productId)
        {
            //HÄMTA ALLA KATEGORIER SOM HÖR TILL DENNA PRODUKTID
            var product = _productService.GetById(productId);
            
            IEnumerable<CategoryPartsViewModel> model = product.Category.MapToList(new List<CategoryPartsViewModel>());
            return View(model);
        }

        public ActionResult GetRelationsPartPartial(int categoryId, int partId)
        {
			//Hämta relationer och uppdatera selectboxarna i Index.cshtml

			var parts = _productService.GetPartsByCategoryId(categoryId);


			var catparts = new CategoryPartsViewModel();
			catparts.Id = categoryId;
			catparts.Name = _productService.GetCategory(categoryId).Name;
			catparts.Parts = new List<PartViewModel>();
			foreach (var part in parts)
			{
				if (_productService.HasRelations(partId, part.Id))
				{
					catparts.Parts.Add(part.MapTo(new PartViewModel()));
				}
			}
			
			return View(catparts);
        }

    }
}
