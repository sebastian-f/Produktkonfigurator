using ProductConfigurator.Domain.Infrastructure;
using ProductConfigurator.Domain.Model;
using ProductConfigurator.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Services.Service
{
    public class OrderService:IOrderService
    {

        private IOrderRepository _orderRepo;

		public OrderService(IOrderRepository orderRepo)
		{
            this._orderRepo = orderRepo;
		}

        public void Save(Domain.Model.Order order, List<Part> partList)
        {
            _orderRepo.SaveOrder(order, partList);
        }

        public Domain.Model.Order Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
