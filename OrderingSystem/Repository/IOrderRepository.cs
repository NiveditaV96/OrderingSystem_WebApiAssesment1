using OrderingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingSystem.Repository
{
   

    public interface IRepository<T> where T : class
    {
        void Place(T t);
        IEnumerable<T> ViewDetails();
        T Update(T t);

    }

    public interface IGetOrderRepository
    {
        Order ViewById(int orderNo);
    }

    //public interface IUpdateOrderRepository
    //{
    //    Order UpdateQuantity(int orderNo, string quantity);
    //    Order UpdateOrderName(int orderNo, string orderName);

    //}
    public interface ICancelOrderRepository
    {
        void CancelOrder(int orderNumber);
    }
}
