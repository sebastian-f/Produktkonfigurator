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
    }
}
