using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Interface;
using ProductConfigurator.Domain.Model;


namespace ProductConfigurator.Services.Service
{
	public class ProductService : IProductService
	{
		private IProductRepository _productRepo;

		public ProductService(IProductRepository productRepo)
		{
            this._productRepo = productRepo;
		}

        //Save new product
        public void SaveProduct(Product product)
        {
            //TODO: Kolla så att id = 0
			if (product.Id <= 0)
			{
				_productRepo.SaveProduct(product);	
			}
			else
			{
				throw new NullReferenceException("id must be 0 or less");
			}
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepo.GetAllProducts();
        }

		public Product GetById(int id)
		{
			if(id > 0)
			{
				return _productRepo.GetProduct(id);
			}
			else
			{
				throw new NullReferenceException("id must be more than 0");
			}
		}

        public void SavePart(Part part)
        {
			if (part.CategoryId > 0 && !string.IsNullOrWhiteSpace(part.Code) && part.DeliveryDate >= DateTime.Today && !string.IsNullOrWhiteSpace(part.Name) && part.Price >= 0 && part.Id <= 0)
			{
				_productRepo.SavePart(part);
			}
			else
			{
				throw new NullReferenceException("error saving part");
			}
        }

        public Part GetPartById(int id)
        {
			if (id > 0)
			{
				return _productRepo.GetPartById(id);
			}
			else
			{
				throw new NullReferenceException("id must be more than 0");
			}
        }

        public void SaveCategory(Category category)
        {
            _productRepo.SaveCategory(category);
        }

		public IEnumerable<Part> GetPartsByCategoryId(int categoryId)
		{
			if (categoryId > 0)
			{
				return _productRepo.GetPartsByCategoryId(categoryId);
			}
			else
			{
				throw new NullReferenceException("id must be more than 0");
			}
		}

		public void SavePartRelation(int one, List<int> two)
		{
			if (one > 0 && two.FirstOrDefault() > 0)
			{
				_productRepo.SavePartRelation(one, two);
			}
			else
			{
				throw new NullReferenceException("ids must be more than 0");
			}
			
		}

		public IQueryable<PartCompatibility> GetRelations(int partId)
		{
			if (partId > 0)
			{
				return _productRepo.GetRelations(partId);
			}
			else
			{
				throw new NullReferenceException("id must be more than 0");
			}
		}


		public bool HasRelations(int partId, int compareTo)
		{
			if (partId > 0 && compareTo > 0)
			{
				return _productRepo.HasRelations(partId, compareTo);
			}
			else
			{
				throw new NullReferenceException("ids must be more than 0");
			}
		}


		public IEnumerable<Part> GetPartsFromCategorysExceptThisPartCategory(int productId, int partId)
		{
			if (productId > 0 && partId > 0)
			{
				var parts = new List<Part>();

				var part = GetPartById(partId);
				foreach (var cat in GetById(productId).Category)
				{
					if (cat.Id != part.CategoryId)
					{
						foreach (var __part in cat.Parts)
						{
							parts.Add(__part);
						}
					}
				}
				return parts;
			}
			else
			{
				throw new NullReferenceException("ids must be more than 0");
			}
		}

		public IEnumerable<Part> GetPartsFromCategory(int productId, int partId)
		{
			var parts = new List<Part>();

			var part = GetPartById(partId);
			foreach (var cat in GetById(productId).Category)
			{
				if (cat.Id == part.CategoryId)
				{
					foreach (var __part in cat.Parts)
					{
						parts.Add(__part);
					}
				}
			}
			return parts;
		}


		public Category GetCategory(int id)
		{
			if (id > 0)
			{
				return _productRepo.GetCategory(id);
			}
			else
			{
				throw new NullReferenceException("id must be more than 0");
			}
		}
	}
}
