using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CheckoutShoppingCart_API.Models
{
    public class Product
    {
        /* Declaration of model properties */
        public int ProductID { get; set; }
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool isChecked { get; set; }
        public int totalIntems { get; set; }
    }

   
}