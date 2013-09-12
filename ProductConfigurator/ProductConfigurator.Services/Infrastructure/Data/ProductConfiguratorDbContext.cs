using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Services.Infrastructure.Data
{
	public class ProductConfiguratorDbContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Part> Parts { get; set; }
	}
}
