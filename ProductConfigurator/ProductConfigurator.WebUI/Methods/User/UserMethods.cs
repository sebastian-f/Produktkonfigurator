using ProductConfigurator.Domain.Model;
using ProductConfigurator.Services.Interface;
using ProductConfigurator.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI.Methods.User
{

    public class UserMethods
    {
        private IProductService _productService;
        private IOrderService _orderService;

        public UserMethods(IProductService productService, IOrderService orderService)
        {
            _productService = productService;
            _orderService = orderService;
        }

        public UserMethods()
        {
            // TODO: Complete member initialization
        }

        public CategoryPartsViewModel GetUpdatedModelForSelectList(int categoryId, string partIdsString)
        {
            var parts = _productService.GetPartsByCategoryId(categoryId).ToList();
            var partIds = partIdsString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<Part>();
            foreach (var part in parts)
            {
                list.Add(part);
            }

            foreach (var partId in partIds)
            {
                foreach (var part in list)
                {
                    if (_productService.GetPartById(int.Parse(partId)).CategoryId != categoryId)
                    {
                        if (!_productService.HasRelations(int.Parse(partId), part.Id))
                        {
                            parts.Remove(part);
                        }
                    }
                }
            }

            var catparts = new CategoryPartsViewModel();
            catparts.Id = categoryId;
            catparts.Name = _productService.GetCategory(categoryId).Name;
            catparts.Parts = new List<PartViewModel>();
            foreach (var part in parts)
            {
                catparts.Parts.Add(part.MapTo(new PartViewModel()));
            }
            return catparts;
        }

        public void CreateOrder(OrderViewModel orderModel, string username)
        {
            Order order = new Order();
            order.Price = orderModel.TotalPrice;
            List<Part> partList = new List<Part>();
            order.DeliveryDate = orderModel.DeliveryDate;

			var codeString = "";

            foreach (var item in orderModel.CategoryParts)
            {
                Part p = _productService.GetPartById(item.PartId);
                partList.Add(p);

				codeString += CodeBefore + item.PartCode + CodeAfter + CodeDevider;
            }
			codeString = codeString.Remove(codeString.LastIndexOf(CodeDevider));
			order.Code = codeString;
            _orderService.Save(order, partList, username);
            
        }

		public static string CodeBefore
		{
			get
			{
				return ConfigurationManager.AppSettings["CodeBefore"];
			}
		}

		public static string CodeAfter
		{
			get
			{
				return ConfigurationManager.AppSettings["CodeAfter"];
			}
		}

		public static string CodeDevider
		{
			get
			{
				return ConfigurationManager.AppSettings["CodeDevider"];
			}
		}
    }
}