using System;
using System.Collections.Generic;
using System.Linq;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Repository.Context;
using System.Data.Entity;

namespace ProductConfigurator.Repository
{
	public class UserRepository : IUserRepository
	{
		private ProductConfiguratorDbContext _context = new ProductConfiguratorDbContext();

		public void SaveUser(Domain.Model.User user)
		{
			if (user.Id <= 0 || GetUserByName(user.Username) != null)
				_context.Users.Add(user);
			else
				_context.Entry(user).State = System.Data.EntityState.Modified;
			_context.SaveChanges();
		}

		public Domain.Model.User GetUserByName(string name)
		{
			return _context.Users.Include(y=>y.Orders.Select(z=>z.Parts)).SingleOrDefault(x => x.Username == name);
		}
	}
}