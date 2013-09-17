﻿using ProductConfigurator.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI
{
	public static class linqExt
	{
		public static Domain.Model.User ToDomainModel(this UserViewModel user)
		{
			AutoMapper.Mapper.CreateMap<UserViewModel, Domain.Model.User>();
			var domainUser = AutoMapper.Mapper.Map<Domain.Model.User>(user);
			
			return domainUser;
		}

	}
}