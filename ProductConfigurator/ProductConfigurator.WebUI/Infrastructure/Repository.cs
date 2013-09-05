using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProductConfigurator
using ProductConfigurator.Domain.Infrastructure;

namespace ProductConfigurator.WebUI.Infrastructure
{
    public class Repository : IRepository
    {
        public void SaveProduct(Domain.Model.Product product)
        {
 	        throw new NotImplementedException();
        }

        public Domain.Model.Product GetProduct(int id)
        {
 	        throw new NotImplementedException();
        }

        public IList<Domain.Model.Product> GetAllProducts()
        {
 	        throw new NotImplementedException();
        }

        public IList<Domain.Model.Category> GetCategory()
        {
 	        throw new NotImplementedException();
        }
    }
}