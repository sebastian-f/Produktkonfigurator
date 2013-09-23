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
            _productRepo.SaveProduct(product);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepo.GetAllProducts();
        }

		public Product GetById(int id)
		{
			return _productRepo.GetProduct(id);
		}

        public void SavePart(Part part)
        {
            _productRepo.SavePart(part);
        }

        public Part GetPartById(int id)
        {
			return _productRepo.GetPartById(id);
        }

        public void SaveCategory(Category category)
        {
            _productRepo.SaveCategory(category);
        }


		public IEnumerable<Part> GetPartsByCategoryId(int categoryId)
		{
			return _productRepo.GetPartsByCategoryId(categoryId);
		}


		public void SavePartRelation(int one, List<int> two)
		{
			//var comp = new PartCompatibility() { PartOne = one, PartTwo = two };
			_productRepo.SavePartRelation(one, two);
		}


		public IQueryable<PartCompatibility> GetRelations(int partId)
		{
			return _productRepo.GetRelations(partId);
		}


		public bool HasRelations(int partId, int compareTo)
		{
			return _productRepo.HasRelations(partId, compareTo);
		}
	}
}
