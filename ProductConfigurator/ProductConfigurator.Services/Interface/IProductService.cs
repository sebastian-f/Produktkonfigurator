using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Services.Interface
{
	public interface IProductService
	{
        void SaveProduct(Product product);
	}
}
