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
			return _context.Products.Include(y=>y.Category).SingleOrDefault(x => x.Id == id);		}

		public IQueryable<Domain.Model.Product> GetAllProducts()
		{
			return _context.Products.Include(x=>x.Category.Select(y=>y.Parts));
		}

		public void SavePart(Domain.Model.Part part)
		{
			_context.Parts.Add(part);
            _context.SaveChanges();
		}

		public Domain.Model.Part GetPartById(int id)
		{
			return _context.Parts.SingleOrDefault(x => x.Id == id);
		}

		public void SaveCategory(Domain.Model.Category category)
		{
			_context.Categorys.Add(category);
            _context.SaveChanges();            
		}

        public IQueryable<Domain.Model.Part> GetPartsByCategoryId(int categoryId)
        {
            return _context.Parts.Where(x => x.CategoryId == categoryId);
        }


		public void SavePartRelation(int oneid, List<int> twoid)
		{
			var one = GetPartById(oneid);
			foreach (var item in twoid)
			{
				var two = GetPartById(item);
				var partComp = new Domain.Model.PartCompatibility() { PartOne = one, PartTwo = two };

				if (!HasRelations(one.Id, two.Id))
					_context.PartCompatibilitys.Add(partComp);
				else
					_context.PartCompatibilitys.Remove(_context.PartCompatibilitys.SingleOrDefault(x => (x.PartOne.Id == oneid && x.PartTwo.Id == twoid.FirstOrDefault()) || (x.PartOne.Id == twoid.FirstOrDefault() && x.PartTwo.Id == oneid)));
			}
			_context.SaveChanges();
		}


		public IQueryable<Domain.Model.PartCompatibility> GetRelations(int partId)
		{
			return _context.PartCompatibilitys.Where(x=>x.PartOne.Id == partId || x.PartTwo.Id == partId);
		}


		public bool HasRelations(int partId, int compareTo)
		{
			if (_context.PartCompatibilitys.FirstOrDefault(x => (x.PartOne.Id == partId && x.PartTwo.Id == compareTo) || (x.PartOne.Id == compareTo && x.PartTwo.Id == partId)) != null)
				return true;
			else
				return false;
		}
	}
}