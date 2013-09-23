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
        void SavePart(Part part);
        Part GetPartById(int id);
		IEnumerable<Part> GetPartsByCategoryId(int categoryId);
		IEnumerable<Part> GetPartsFromCategorysExceptThisPartCategory(int productId, int partId);
        void SaveCategory(Category category);
		void SavePartRelation(int one, List<int> two);
		IQueryable<PartCompatibility> GetRelations(int partId);
		bool HasRelations(int partId, int compareTo);
	}
}
