using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using ProductConfigurator.Domain.Model;
using System.Web.Security;

namespace ProductConfigurator.Repository.Context
{
	public class ProductConfiguratorDbContext : DbContext
	{
		public ProductConfiguratorDbContext()
		{
			if (Database.CreateIfNotExists())
			{
				if (!Database.CompatibleWithModel(false))
				{
					try
					{
						Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProductConfiguratorDbContext>());
						this.Database.Initialize(true);
					}
					catch (Exception ex)
					{
						throw new NullReferenceException("", ex);
					}
				}
				System.Diagnostics.Process firstProc = new System.Diagnostics.Process();
				firstProc.StartInfo.WorkingDirectory = @"C:\Windows\Microsoft.NET\Framework\v2.0.50727";
				firstProc.StartInfo.FileName = "aspnet_regsql.exe";
				firstProc.EnableRaisingEvents = true;

				firstProc.Start();

				firstProc.WaitForExit();

				var role = Roles.Provider;

				if (!role.RoleExists("Admin"))
				{
					role.CreateRole("Admin");
				}
				if (Membership.GetUser("Admin", false) == null)
				{
					Membership.CreateUser("Admin", "Admin1!");
				}
				if (!role.GetRolesForUser("Admin").Contains("Admin"))
				{
					role.AddUsersToRoles(new[] { "Admin" }, new[] { "Admin" });
				} 
			}
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categorys { get; set; }
		public DbSet<Part> Parts { get; set; }
		public DbSet<PartCompatibility> PartCompatibilitys { get; set; }
		
	}
}
