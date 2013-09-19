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

		
		IQueryable<Part> GetPartsByCategoryId(int categoryId);
        void SavePart(Part part);
		Part GetPartById(int id);

		void SavePartRelation(int oneid, List<int> twoid);
		IQueryable<PartCompatibility> GetRelations(int partId);
		bool HasRelations(int partId, int compareTo);

		void SaveCategory(Category category);

        
	}
}
