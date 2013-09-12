using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Domain.Infrastructure
{
	public interface IProductRepository
	{
		void SaveProduct(Product product);
		Product GetProduct(int id);
		IQueryable<Product> GetAllProducts();

		void SavePart(Part part);
		Part GetPartByCode(string code);

		void SaveCategory(Category category);
	}
}
