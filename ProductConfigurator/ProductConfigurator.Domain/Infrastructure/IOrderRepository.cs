using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductConfigurator.Domain.Model;

namespace ProductConfigurator.Domain.Infrastructure
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        void SaveOrder(Order order, List<Part> partList);
        Order Get(int id);
        void SendOrder(Order order);
    }
}
