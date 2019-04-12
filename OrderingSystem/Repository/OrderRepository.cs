using OrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace OrderingSystem.Repository
{
    public class OrderRepository : IRepository<Order>, IUpdateOrderRepository<OrderPatchRequest>, 
                                    IGetOrderRepository, ICancelOrderRepository
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("OrderRepository");

        private static List<Order> orders = new List<Order>()
        {
            new Order {Id=1, Name="order1", Price=2000, Quantity=10},

        };

        public async Task Create(Order order)
        {
            List<Order> o1 = orders.FindAll(o => o.Id == order.Id);
            
            

            if (order == null)
            {
                throw new ArgumentException("Cannot place empty order", "order");
            }
            //else if(order.Id == (orders.FindAll(o => o.Id == order.Id)))
            //{

            //}

            
            Task order1 = Task.Run(() => orders.Add(order));

            _log.Info(string.Format("Order created with Id {0} for order name {1}, quantity {2} and price {3}",
                                        order.Id, order.Name, order.Quantity, order.Price));
            await order1;
        }

        public  IEnumerable<Order> GetAll()
        {
           
            _log.Info("View all order details");
            return orders;
          
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            Task<Order> order = Task.Run(() => orders.FirstOrDefault(o => o.Id == id));
            _log.Info($"Order details for id {id}");
            return await order;
        }

        //Order Update(Order order)
        //{
        //    ////Order order1 = orders.Where(o => o.Id == orderNo).First();

        //    ////order1.Id = order.Id;
        //    ////order1.Name = order.Name;
        //    ////order1.Price = order.Price;
        //    ////order1.Quantity = order.Quantity;

        //    ////_log.Info("update an order");
        //    ////return orders.FirstOrDefault(o => o.Id == order.Id);
        //    //Order order1 = orders.Find(o => o.Id == order.Id);

        //    //order1.Id = order.Id;
        //    //order1.Name = order.Name;
        //    //order1.Price = order.Price;
        //    //order1.Quantity = order.Quantity;

        //    //_log.Info("update an order");
        //    //return orders.FirstOrDefault(o => o.Id == order.Id);
        //}

        public async Task<bool> Cancel(int id)
        {
            Task<Order> order = Task.Run(() => orders.FirstOrDefault(o1 => o1.Id == id));

            //Task<Order> order = Task.Run(() => orders.FirstOrDefault(o => o.Id == id));

            Order o = await order;
            if (o != null)
            {
                orders.Remove(o);
                _log.Info(string.Format($"Order with id {id} is cancelled."));
                return true;
            }
            else
            {
                _log.Error(string.Format($"Order with id {id} does not exist."));
                return false;
            }
        }

        public async Task<bool> Update(OrderPatchRequest order)
        {
            //Order order1 = orders.Where(o => o.Id == orderNo).First();

            //order1.Id = order.Id;
            //order1.Name = order.Name;
            //order1.Price = order.Price;
            //order1.Quantity = order.Quantity;

            //_log.Info("update an order");
            //return orders.FirstOrDefault(o => o.Id == order.Id);
            Task<Order> order1 = Task.Run(() => orders.FirstOrDefault(o1 => o1.Id == order.Id));
            Order o = await order1;
           
            var tempOrder = o;

            if(o == null)
            {
                return false;
            }
            else
            {
                o.Id = order.Id;
                o.Price = order.Price;
                o.Quantity = order.Quantity;
            }

            _log.Info(string.Format("Order with id {0} has updated its price from {1} to {2} and quantity from {3} to {4}",
                                          order.Id, tempOrder.Price, order.Price, tempOrder.Quantity, order.Quantity));
            return true;
        }

      
    }
}