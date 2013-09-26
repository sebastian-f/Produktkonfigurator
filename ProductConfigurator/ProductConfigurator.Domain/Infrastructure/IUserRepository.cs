using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Domain.Infrastructure
{
	public interface IUserRepository
	{
		void SaveUser(User user);
		User GetUserByName(string name);

	}
}
