using ProductConfigurator.WebUI.Models;
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
			var domainUser = AutoMapper.Mapper.Map<Domain.Model.User>(user);
			/*var domainUser = new Domain.Model.User();
			domainUser.Id = user.Id;
			domainUser.Username = user.Username;
			domainUser.Telephone = user.Telephone;
			domainUser.Email = user.Email;
			domainUser.Company = user.Company;
			domainUser.StreetName = user.StreetName;
			domainUser.ZipCode = user.ZipCode;
			domainUser.City = user.City;
			domainUser.Country = user.Country;*/
			

			return domainUser;
		}

	}
}