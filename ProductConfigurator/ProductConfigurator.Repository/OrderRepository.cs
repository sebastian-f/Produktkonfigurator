using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ProductConfiguratorDbContext _context = new ProductConfiguratorDbContext();

        public void SaveOrder(Domain.Model.Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Domain.Model.Order Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
