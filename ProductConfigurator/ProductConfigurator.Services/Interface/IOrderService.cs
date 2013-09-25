using ProductConfigurator.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Services.Interface
{
    public interface IOrderService
    {
        void SendOrder(int id);
        IEnumerable<Order> GetAll();
        void Save(Order order, List<Part> partList);
        Order Get(int id);
    }
}
