﻿using ProductConfigurator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Services.Interface
{
	public interface IUserService
	{
		void CreateUser(User user);
	}
}
