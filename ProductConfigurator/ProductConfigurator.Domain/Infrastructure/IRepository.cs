using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Domain.Infrastructure
{
	public interface IRepository
	{
		void SaveProduct(Product product);

		Product GetProduct(int id);
		IList<Product> GetAllProducts();

		IList<Category> GetCategory();

	}
}
