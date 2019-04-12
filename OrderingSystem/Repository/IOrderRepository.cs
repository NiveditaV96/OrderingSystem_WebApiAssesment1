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
        Task Create(T t);
        IEnumerable<T> GetAll();

    }

    public interface IGetOrderRepository
    {
       Task<Order> GetByIdAsync(int id);
    }

    public interface IUpdateOrderRepository<T> where T : class
    {
        Task<bool> Update(T t);
       
    }
    public interface ICancelOrderRepository
    {
        Task<bool> Cancel(int id);
    }
}
