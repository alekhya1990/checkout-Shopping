using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckoutShoppingCart_API.Models;
using CheckoutShoppingCart_API.Services;
using System.Web;
using System.Web.Providers.Entities;

namespace CheckoutShoppingCart_API.Controllers
{
    public class CartController : ApiController
    {
        /* Get list of Items and display on Cart page */
        [HttpGet]
        public List<Product> GetCartProducts(List<Product> cartList)
        {

            //Get the list of items from the current session (Items selected in Product page)
            cartList = (List<Product>)HttpContext.Current.Session["CartList"];

            return cartList;

        }

        /* Web API post method to remove the list of selected items in Cart page */
        [HttpPost]
        public HttpResponseMessage RemoveItem([FromBody] List<int> removeItems)
        {
            //Intialise service object to access service methods
            ProductServices productService = new ProductServices();

            //Return list of items after removing the selected ietms by the user
            var cartItems = productService.RemoveItemsFromCart(removeItems, (List<Product>)HttpContext.Current.Session["CartList"]);

            //Update  session with the latest list after removing the items
            HttpContext.Current.Session["CartList"] = (List<Product>)cartItems;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Location = new Uri("http://localhost:55857/Cart");

            return response;

        }

        /* Web API post method to change the quantity of each item in cart */
        [HttpPost]
        public HttpResponseMessage ChangeQuantity([FromBody] List<Product> items, string quantity)
        {
            //Intialise service object to access service methods
            ProductServices productService = new ProductServices();

            //Return list of items after removing the selected ietms by the user
            var cartItems = productService.ChangeQuantity(items);

            //Update  session with the latest list after removing the items
            HttpContext.Current.Session["CartList"] = (List<Product>)cartItems;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Location = new Uri("http://localhost:55857/Cart");

            return response;

        }
    }
}
