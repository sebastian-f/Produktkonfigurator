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
        void SaveOrder(Order order);
        Order Get(int id);
    }
}
