using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckoutShoppingCart_API.Models;
using CheckoutShoppingCart_API.Services;
using System.Web;
using System.Web.ModelBinding;
using System.Web.SessionState;
using System.Web.Providers.Entities;

namespace CheckoutShoppingCart_API.Controllers
{
    public class ProductController : ApiController
    {
        /* Get list of products and details of each product to display on Products screen */
        [HttpGet]
        public List<Product> GetAllProducts()
        {
            ProductServices productService = new ProductServices();

            //Check the already selected items in cart and display the status on Product screen
            var productsList = productService.GetProducts();
            var cartList = (List<Product>)HttpContext.Current.Session["CartList"];

            //return the latest products list
            productsList = (cartList != null ? productService.GetItemsFromCart(productsList, cartList) : productsList);

            return productsList;

        }

        /* Web API post method to add list of selected items to car */
        [HttpPost]
        public HttpResponseMessage Post([FromBody] List<int> productsIDs)
        {
            ProductServices productService = new ProductServices();
            List<Product> cartList = productService.AddToCart(productsIDs);

            //Update session with the current cart list
            HttpContext.Current.Session["CartList"] = cartList;

            var response = Request.CreateResponse(HttpStatusCode.OK);

            response.Headers.Location = new Uri("http://localhost:55857/Cart");

            return response;

        }

    }
}