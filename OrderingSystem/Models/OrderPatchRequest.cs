using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystem.Models
{
    public class OrderPatchRequest
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
    }
}