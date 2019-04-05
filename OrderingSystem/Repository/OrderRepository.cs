using OrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystem.Repository
{
    public class OrderRepository : IRepository<Order>, IGetOrderRepository
    {
        private static readonly log4net.ILog _log = log4net.LogManager.GetLogger("OrderRepository");

        private static List<Order> orders = new List<Order>()
        {
            new Order {Number=1, Name="order1", Price=2000, Quantity=10},

        };

        public void Place(Order order)
        {
            if (order == null)
            {
                throw new ArgumentException("Cannot place empty order", "order");
            }
            orders.Add(order);
            _log.Info("Placing order");
        }

        public IEnumerable<Order> ViewDetails()
        {
            _log.Info("View all order details");
            return orders;
          
        }

        public Order ViewById(int orderNo)
        {
            _log.Info("View order by order no");
            return orders.FirstOrDefault(o => o.Number == orderNo);
        }

        public Order Update(Order order)
        {
            Order order1 = orders.Find(o => o.Number == order.Number);

            order1.Number = order.Number;
            order1.Name = order.Name;
            order1.Price = order.Price;
            order1.Quantity = order.Quantity;

            _log.Info("update an order");
            return orders.FirstOrDefault(o => o.Number == order.Number);
        }

        void CancelOrder(int orderNumber)
        {
             var order = orders.FirstOrDefault(o => o.Number == orderNumber);

            _log.Info("order cancelled");

            if (order != null)
                orders.Remove(order);
        }
       
    }
}