using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderingSystem.Models
{

    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public int Quantity { get; set; }
    //}
    public class Order
    {
        public int Id { get; set; }

        //public List<Product> Products { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        // public string Status { get; set; }
        //public List<string> Status { get; set; }

    }
}