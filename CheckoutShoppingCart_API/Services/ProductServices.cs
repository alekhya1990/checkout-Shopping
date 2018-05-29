using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CheckoutShoppingCart_API.Models;

namespace CheckoutShoppingCart_API.Services
{
    public class ProductServices
    {
        /* Store data in a local memory by creating List objects */
        public List<Product> GetProducts()
        {
            List<Product> productList = new List<Product>();
            Product product = new Product
            {
                ProductID = 1,
                ImageUrl = "../Images/Watch1.jpg",
                Name = "Watch #1",
                Price = 100,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 2,
                ImageUrl = "../Images/Watch2.jpg",
                Name = "Watch #2",
                Price = 200,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 3,
                ImageUrl = "../Images/Watch3.jpg",
                Name = "Watch #3",
                Price = 300,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 4,
                ImageUrl = "../Images/Watch4.jpg",
                Name = "Watch #4",
                Price = 400,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 5,
                ImageUrl = "../Images/Watch5.jpg",
                Name = "Watch #5",
                Price = 500,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 6,
                ImageUrl = "../Images/Watch6.jpg",
                Name = "Watch #6",
                Price = 600,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 7,
                ImageUrl = "../Images/Watch7.jpg",
                Name = "Watch #7",
                Price = 700,
                isChecked = false
            };


            productList.Add(product);

            product = new Product
            {
                ProductID = 8,
                ImageUrl = "../Images/Watch8.jpg",
                Name = "Watch #8",
                Price = 800,
                isChecked = false
            };


            productList.Add(product);

            product.ProductID = 9;
            product.ImageUrl = "../Images/Watch9.jpg";
            product.Name = "Watch #9";
            product.Price = 900;
            product.isChecked = false;

            productList.Add(product);

            return productList;

        }

        /* Business logic to get the total ietms in the Cart */
        public List<Product> GetItemsFromCart(List<Product> totalProducts, List<Product> cartItems)
        {
            List<Product> productsList = new List<Product>();
            foreach (var item in totalProducts)
            {
                var isPresent = cartItems.Where(s => s.ProductID == item.ProductID).ToList();
                if (isPresent.Count > 0)
                {
                    isPresent.First().isChecked = true;
                    productsList.Add(isPresent.First());

                }
                else
                    productsList.Add(item);

            }

            return productsList;

        }

        /* Business logic to add the selected items to Cart */
        public List<Product> AddToCart(List<int> ids)
        {
            List<Product> productsList = GetProducts();
            List<Product> cartList = new List<Product>();

            foreach (int id in ids)
            {
                Product item = (Product)productsList.Where(s => s.ProductID == id).First();
                item.Quantity = 1;
                cartList.Add(item);
            }

            return cartList;

        }

        /* Business logic to remove selected items from Cart */
        public List<Product> RemoveItemsFromCart(List<int> ids, List<Product> cartItems)
        {
            List<Product> productsList = new List<Product>();
            foreach (var id in ids)
            {
                cartItems.RemoveAll(s => s.ProductID == id);

            }

            return cartItems;

        }


        /* Business logic to change quantity in Cart */
        public List<Product> ChangeQuantity(List<Product> cartItems)
        {
            List<Product> productsList = new List<Product>();
            foreach (var item in cartItems)
            {
                cartItems.Where(s => s.ProductID == item.ProductID).First().Quantity = item.Quantity;

            }

            return cartItems;

        }
    }
}