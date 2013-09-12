using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Interface;


namespace ProductConfigurator.Services.Service
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepo;

		public UserService(IUserRepository userRepo)
		{
			this._userRepo = userRepo;
		}

	}
}
