using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutShoppingCart_API.Services;
using CheckoutShoppingCart_API.Models;
using System.Collections.Generic;

namespace CheckShoppingCart_API_UnitTest
{
    [TestClass]
    public class ProductsTest
    {
        // An example for a sample test case  
        public const string ItemsIncartExceedsTotalProducts = "Items in Cart exceeds with the total variety of Items in products ";
        public const string DebitAmountLessThanZeroMessage = "Debit amount less than zero"; 

        [TestMethod]
        public void Display_Products_withValidItems_InSession()
        {
            //arrange
            List<Product> totalProducts = new List<Product>();
            List<Product> cartItems = new List<Product>();

            Product product = new Product
            {
                ProductID = 1,
                ImageUrl = "../Images/Watch1.jpg",
                Name = "Watch #1",
                Price = 100,
                isChecked = false
            };

            totalProducts.Add(product);
            cartItems.Add(product);

            product = new Product
            {
                ProductID = 2,
                ImageUrl = "../Images/Watch2.jpg",
                Name = "Watch #2",
                Price = 200,
                isChecked = false
            };

            cartItems.Add(product);

            ProductServices productService = new ProductServices();
            
            //act
            var items = productService.GetItemsFromCart(totalProducts, cartItems);

            //assert
            if (cartItems.Count > totalProducts.Count)
            {
                throw new ArgumentOutOfRangeException("ItemsInCart", cartItems.Count, ItemsIncartExceedsTotalProducts); 
            }

        }
    }
}
