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
	public class ProductService : IProductService
	{
		private IProductRepository _prodoceRepo;

		public ProductService(IProductRepository procuceRepo)
		{
			this._prodoceRepo = procuceRepo;
		}
	}
}
