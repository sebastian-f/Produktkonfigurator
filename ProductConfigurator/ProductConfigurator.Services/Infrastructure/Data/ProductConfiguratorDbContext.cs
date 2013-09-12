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
		public ProductConfiguratorDbContext()
		{
			if (!this.Database.CompatibleWithModel(false))
			{
				try
				{
					Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductConfiguratorDbContext>());
					this.Database.Initialize(true);

					System.Diagnostics.Process firstProc = new System.Diagnostics.Process();
					firstProc.StartInfo.WorkingDirectory = @"C:\Windows\Microsoft.NET\Framework\v2.0.50727";
					firstProc.StartInfo.FileName = "aspnet_regsql.exe";
					firstProc.EnableRaisingEvents = true;

					firstProc.Start();

					firstProc.WaitForExit();
				}
				catch (Exception)
				{

					throw new NullReferenceException("Membership instance failed take a look at ProdConf.Services.Infrastructure.Data.ProductConfigurationDbContext");
				}
			}
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Part> Parts { get; set; }
	}
}
