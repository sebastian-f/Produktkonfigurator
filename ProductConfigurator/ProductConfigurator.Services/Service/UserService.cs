using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Services.Interface;
using ProductConfigurator.Domain.Model;


namespace ProductConfigurator.Services.Service
{
	public class UserService : IUserService
	{
		private IUserRepository _userRepo;

		public UserService(IUserRepository userRepo)
		{
			this._userRepo = userRepo;
		}

		public void CreateUser(Domain.Model.User user)
		{
            User testUser =_userRepo.GetUserByName(user.Username);
            if (testUser == null)
            {
                _userRepo.SaveUser(user);
            }
		}
	}
}
