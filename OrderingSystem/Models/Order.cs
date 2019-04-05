using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystem.Models
{
    public class Order
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
       // public string Status { get; set; }
        //public List<string> Status { get; set; }

    }
}