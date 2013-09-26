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
        private IUserRepository _userRepo;


		public OrderService(IOrderRepository orderRepo,IUserRepository userRepo)
		{
            this._orderRepo = orderRepo;
            this._userRepo = userRepo;
		}

        public void Save(Domain.Model.Order order, List<Part> partList,string userName)
        {
            User user = _userRepo.GetUserByName(userName);
            order.OrdersUser = user;
            //TODO: Gör klart
            if (userName != null && order.Price != 0 && partList.Count>0)
            {
                _orderRepo.SaveOrder(order, partList);
            }
        }

        public Domain.Model.Order Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepo.GetAll();
        }

        public void SendOrder(int id)
        {
            try
            {
                var order = _orderRepo.Get(id);
                order.Sent = true;
                _orderRepo.SendOrder(order);

                IMailService mail = new MailService();
                //TODO:
                //mail.SendMail(order.OrdersUser.Email,"UserName","Order skickad!","Din order är skickad!<br><br>Order: "+order.Id+"<br>Skickad: "+DateTime.Now.ToString());
            }
            catch {
                //Hittade inte id
            }
        }
    }
}
