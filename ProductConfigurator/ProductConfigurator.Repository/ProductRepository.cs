using System;
using System.Collections.Generic;
using System.Linq;
using ProductConfigurator;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Repository.Context;
using System.Data.Entity;

namespace ProductConfigurator.Repository
{
    public class ProductRepository : IProductRepository
    {
		private ProductConfiguratorDbContext _context = new ProductConfiguratorDbContext();

		public void SaveProduct(Domain.Model.Product product)
		{
			_context.Products.Add(product);
            _context.SaveChanges();
		}

		public Domain.Model.Product GetProduct(int id)
		{
			return _context.Products.Include(y=>y.Category.Select(z=>z.Parts)).SingleOrDefault(x => x.Id == id);
		}

		public IQueryable<Domain.Model.Product> GetAllProducts()
		{
			return _context.Products.Include(x=>x.Category.Select(y=>y.Parts));
		}

		public void SavePart(Domain.Model.Part part)
		{
			_context.Parts.Add(part);
		}

		public Domain.Model.Part GetPartByCode(string code)
		{
			return _context.Parts.SingleOrDefault(x => x.Code == code);
		}

		public void SaveCategory(Domain.Model.Category category)
		{
			_context.Categorys.Add(category);
		}
	}
}