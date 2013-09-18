using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Services.Interface
{
	public interface IProductService
	{
        IEnumerable<Product> GetAll();
		Product GetById(int id);
        void SaveProduct(Product product);
        void SavePart(Part part, int categoryId);
        Part GetPartByCode(string code);
        void SaveCategory(Category category, int productId);
	}
}
