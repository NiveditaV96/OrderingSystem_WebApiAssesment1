using OrderingSystem.Filter;
using OrderingSystem.Models;
using OrderingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrderingSystem.Controllers
{
    [Logger]
    public class OrderingSystemController : ApiController
    {
        IRepository<Order> _orderRepository;
        IGetOrderRepository _getOrderRepository;
        ICancelOrderRepository _cancelOrderRepository;
        IUpdateOrderRepository<OrderPatchRequest> _updateOrderRepository;

        public OrderingSystemController(IRepository<Order> orderRepository,
                                        IGetOrderRepository getOrderRepository,
                                        ICancelOrderRepository cancelOrderRepository,
                                        IUpdateOrderRepository<OrderPatchRequest> updateOrderRepository)
        {
            _orderRepository = orderRepository;
            _getOrderRepository = getOrderRepository;
            _cancelOrderRepository = cancelOrderRepository;
            _updateOrderRepository = updateOrderRepository;

        }

        [HttpPost]
        
        public async Task<IHttpActionResult> CreateOrderAsync(Order order)
        {
            await _orderRepository.Create(order);
            //await Task.Run(()=> _orderRepository.Create(order));
            
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            Task<IEnumerable<Order>> getAllResult = Task.Run(() => _orderRepository.GetAll());
            IEnumerable<Order> orders = await getAllResult;

            return Ok(orders);
            
        }


        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IHttpActionResult> GetByIdAsync(int id)
        {
            var order = await _getOrderRepository.GetByIdAsync(id);

            if (order == null)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, "The requested order does not exist."));
            }

            else
            {
                return Ok(order);
            }
        }

        [HttpPatch]
        public async Task<IHttpActionResult> UpdateOrderAsync([FromBody]OrderPatchRequest request)
        {
            var updateStatus = await _updateOrderRepository.Update(request);

            if(updateStatus)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
            }
            else
            {
                //return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest));
                return BadRequest(string.Format("The order id {0} and update details cannot be null",request.Id));
            }

            
          
        }

        [HttpDelete]
        public async Task<IHttpActionResult> CancelOrderAsync(int id)
        {
            bool cancelStatus = await _cancelOrderRepository.Cancel(id);
            if(cancelStatus)
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, "Order cancelled"));
            }
            else
            {
                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, $"Order with id: {id} does not exist to cancel."));
            }
            
        }


    }
}
