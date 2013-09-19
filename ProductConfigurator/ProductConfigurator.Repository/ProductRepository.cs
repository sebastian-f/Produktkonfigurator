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
			return _context.Products.Include(y=>y.Category).SingleOrDefault(x => x.Id == id);
		}

		public IQueryable<Domain.Model.Product> GetAllProducts()
		{
			return _context.Products.Include(x=>x.Category);
		}

		public void SavePart(Domain.Model.Part part)
		{
			/*
			Domain.Model.Part part2 = new Domain.Model.Part
			{
				Name = "part3",
				Price = 15,
				CategoryId = 1,
				DeliveryDate = DateTime.Now,
				Code = "AB",
				CompatibleParts =
					new List<Domain.Model>
				{ 
					new Domain.Model.Part
					{ 
						Name="part93", Price=15, CategoryId=1, DeliveryDate=DateTime.Now, Code="AB" 
					}, 
					new Domain.Model.Part
					{ 
						Name="part40", Price=15, CategoryId=1, DeliveryDate=DateTime.Now, Code="AB" 
					}
				}
			};

			*/
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

			return _context.Parts.Where(x=>x.CategoryId == categoryId);
            //return _context.Categorys.SingleOrDefault(x => x.Id == categoryId).Parts as IQueryable<Domain.Model.Part>;
        }


		public void SavePartRelation(Domain.Model.PartCompatibility comp)
		{
			_context.PartCompatibilitys.Add(comp);
		}


		public IQueryable<Domain.Model.PartCompatibility> GetRelations(int partId)
		{
			return _context.PartCompatibilitys.Where(x=>x.PartOne.Id == partId || x.PartTwo.Id == partId);
		}
	}
}