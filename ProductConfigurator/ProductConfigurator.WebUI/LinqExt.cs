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

			return domainUser;
		}

        public static Domain.Model.Product ToDomainModel(this ProductViewModel product) 
        {
            var domainProduct = AutoMapper.Mapper.Map<Domain.Model.Product>(product);
            return domainProduct;
        }

	}
}