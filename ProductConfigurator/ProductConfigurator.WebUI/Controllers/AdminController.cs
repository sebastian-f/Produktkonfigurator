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
			part.DeliveryDate = new DateTime(2014, 1, 1);

			_productService.SavePart(part.MapTo(new Domain.Model.Part()));
			return RedirectToAction("Index");
		}

		public ActionResult PartDetailsPartial(int id)
		{
			var parts = _productService.GetPartsByCategoryId(_productService.GetPartById(id).CategoryId).MapToList(new List<PartViewModel>());
			foreach (var part in parts)
			{
				var hasRelation = _productService.HasRelations(id, part.Id);

				//Response.Write(_productService.GetPartById(id).Name + " " + part.Name + " " + b + "</br>");

				part.Checked = hasRelation;

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