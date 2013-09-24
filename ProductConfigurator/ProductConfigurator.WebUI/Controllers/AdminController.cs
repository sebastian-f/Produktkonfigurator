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

        public ActionResult Orders()
        {
            //TODO: GetAllOrders - service
    
            List<HandleOrderViewModel> orders = new List<HandleOrderViewModel>();
            orders.Add(new HandleOrderViewModel { DeliveryDate = DateTime.Now, ProductName = "Hej!", TotalPrice = 5000,Id=1});

            return View(orders);
        }

        [HttpPost]
        public ActionResult SendOrder(OrderViewModel order)
        {
            //TODO: FINISH
            return View();
        }

		public ActionResult ProductPartial()
		{
			var productViewModel = _productService.GetAll().MapToList(new List<ProductViewModel>());
			return View(productViewModel);
		}

		public ActionResult AddProduct(string name)
		{
			var product = new ProductViewModel() { Name = name };

			_productService.SaveProduct(product.MapTo(new Domain.Model.Product()));
			return RedirectToAction("Index");
		}

		public ActionResult CategoryPartial(int id)
		{
			var categoryViewModel = _productService.GetById(id).Category.MapToList(new List<CategoryViewModel>());

			return View(categoryViewModel);
		}

		public ActionResult AddCategory(string name, int productId)
		{
			var category = new CategoryViewModel() { Name = name, ProductId = productId };

			_productService.SaveCategory(category.MapTo(new Domain.Model.Category()));
			return RedirectToAction("Index");
		}

		public ActionResult PartPartial(int id)
		{
			var partViewModel = _productService.GetPartsByCategoryId(id).MapToList(new List<PartViewModel>());

			return View(partViewModel);
		}

		public ActionResult AddPart(PartViewModel part, int categoryId)
		{
			//var part = new PartViewModel() { Name = name, CategoryId = categoryId };

			part.CategoryId = categoryId;


			_productService.SavePart(part.MapTo(new Domain.Model.Part()));
			return RedirectToAction("Index");
		}

		public ActionResult PartDetailsPartial(int productId, int partId)
		{
			//var parts = _productService.GetPartsByProductId(id).MapToList(new List<PartViewModel>());

			var parts = _productService.GetPartsFromCategorysExceptThisPartCategory(productId, partId).MapToList(new List<PartViewModel>());
			
			//var parts = _productService.GetPartsByCategoryId(_productService.GetPartById(id).CategoryId).MapToList(new List<PartViewModel>());
			foreach (var __part in parts)
			{
				var hasRelation = _productService.HasRelations(partId, __part.Id);

				//Response.Write(_productService.GetPartById(id).Name + " " + part.Name + " " + b + "</br>");

				__part.Checked = hasRelation;

			}

			return View(parts);
		}

		public ActionResult AddRelation(int oneId, int[] twoId)
		{

			_productService.SavePartRelation(oneId, twoId.ToList());
			

			return RedirectToAction("Index");
		}
    }
}