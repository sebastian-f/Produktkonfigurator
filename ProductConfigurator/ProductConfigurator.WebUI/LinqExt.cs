using ProductConfigurator.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductConfigurator.WebUI
{
	public static class linqExt
	{
		public static U MapTo<T, U>(this T model, U mapTo) where U : new()
		{
			AutoMapper.Mapper.CreateMap<T, U>();
			var mappedTo = AutoMapper.Mapper.Map<U>(model);

			return mappedTo;
		}

        public static IEnumerable<U> MapToList<T, U>(this IEnumerable<T> model, IEnumerable<U> mapTo)
        {
            AutoMapper.Mapper.CreateMap<T, U>();
            var mappedTo = AutoMapper.Mapper.Map<IEnumerable<T>, IEnumerable<U>>(model);
            return mappedTo;
        }

		public static Domain.Model.User ToDomainModel(this UserViewModel user)
		{
			AutoMapper.Mapper.CreateMap<UserViewModel, Domain.Model.User>();
			var domainUser = AutoMapper.Mapper.Map<Domain.Model.User>(user);
			
			return domainUser;
		}

        public static Domain.Model.Product ToDomainModel(this ProductViewModel product) 
        {
            //TODO:Flytta
            AutoMapper.Mapper.CreateMap<ProductViewModel, Domain.Model.Product>();
         
            var domainProduct = AutoMapper.Mapper.Map<Domain.Model.Product>(product);
            return domainProduct;
        }
        public static IEnumerable<ProductViewModel> ToViewModel(this IEnumerable<Domain.Model.Product> products)
        {
            //TODO:Flytta
            AutoMapper.Mapper.CreateMap<Domain.Model.Product, ProductViewModel>();

            IList<ProductViewModel> productsViewModel = new List<ProductViewModel>();
            foreach(ProductConfigurator.Domain.Model.Product prod in products)
            {
                productsViewModel.Add(AutoMapper.Mapper.Map<ProductViewModel>(prod));
            }
            return productsViewModel;
        }

	}
}