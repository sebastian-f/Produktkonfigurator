using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Domain.Model;
using ProductConfigurator.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private ProductConfiguratorDbContext _context = new ProductConfiguratorDbContext();

        public void SaveOrder(Domain.Model.Order order, List<Part> partList)
        {
            order.Sent = false;
            _context.Orders.Add(order);
            foreach (var item in partList)
            {
                _context.Parts.Attach(item);
            }
            order.Parts = partList;
            _context.SaveChanges();
        }

        public Domain.Model.Order Get(int id)
        {
            return _context.Orders.Include(x=>x.OrdersUser).
                        SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            //TODO: _context.Orders.Include...
            return _context.Orders;
        }


        public void SendOrder(Order order)
        {
            _context.Entry(order).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
