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
    public class ItemsController : ApiController
    {
        /* Web API post method to change the quantity of each item in cart */
        [HttpPost]
        public HttpResponseMessage ChangeQuantity([FromBody] List<Product> items)
        {
            //Intialise service object to access service methods
            ProductServices productService = new ProductServices();

            //Return list of items after removing the selected ietms by the user
            var cartItems = productService.ChangeQuantity(items, (List<Product>)HttpContext.Current.Session["CartList"]);

            //Update  session with the latest list after removing the items
            HttpContext.Current.Session["CartList"] = (List<Product>)cartItems;

            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Headers.Location = new Uri("http://localhost:55857/Cart");

            return response;

        }

    }
}
