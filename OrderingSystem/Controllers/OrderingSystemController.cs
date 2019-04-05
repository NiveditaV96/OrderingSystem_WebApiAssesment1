using OrderingSystem.Models;
using OrderingSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderingSystem.Controllers
{
    public class OrderingSystemController : ApiController
    {
        IRepository<Order> _orderRepository;
        IGetOrderRepository _getOrderRepository; 
        ICancelOrderRepository _cancelOrderRepository;

        public OrderingSystemController(IRepository<Order> orderRepository,
                                        IGetOrderRepository getOrderRepository,
                                        ICancelOrderRepository cancelOrderRepository)
        {
            _orderRepository = orderRepository;
            _getOrderRepository = getOrderRepository;
            _cancelOrderRepository = cancelOrderRepository;
        }

        [HttpPost]
        public IHttpActionResult PlaceOrder(Order order)
        {
            _orderRepository.Place(order);
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.Created));
        }

        [HttpGet]
        public IHttpActionResult ViewAllOrderDetails()
        {
            return Ok(_orderRepository.ViewDetails());
        }


        [HttpGet]
        public IHttpActionResult ViewOrderByNumber(int orderNo)
        {

            return Ok(_getOrderRepository.ViewById(orderNo));
        }

        [HttpPut]
        public IHttpActionResult UpdateOrder(Order order)
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _orderRepository.Update(order)));
          
        }

        [HttpDelete]
        public IHttpActionResult CancelOrder(int orderNo)
        {
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, _cancelOrderRepository.CancelOrder(orderNo)));
        }





    }
}
