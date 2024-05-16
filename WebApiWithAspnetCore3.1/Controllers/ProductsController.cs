using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiWithAspnetCore31.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiWithAspnetCore31.Controllers
{
    // [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController] // automatic (de)serialization
    public class ProductsController : Controller
    {
        static List<Product> _products = new List<Product>()
            {
                new Product() { ProductId = 1, ProductName = "Laptop", ProductPrice = 99.23M },
                new Product() { ProductId = 2, ProductName = "Desktop", ProductPrice = 55.34M },
                new Product() { ProductId = 3, ProductName = "Apple", ProductPrice = 12.23M },
            };

        // GET: api/<controller>
        //[HttpGet]
        //public IEnumerable<Product> Get()
        //{
        //    return _products;

        //}


        // same as Get method 
        // As long as method prefix is "Get" which is same as Http Verb "Get"
        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_products);
            // return StatusCode(StatusCodes.Status201Created);
        }

        // Custom method
        // NOTE: unless giving name, "Get" has two, which went wrong
        // /api/products/LoadWelcomeMessage
        [HttpGet("LoadWelcomeMessage")]
        public IActionResult GetWelcomeMessage()
        {
            return Ok("Welcome to our store...");
        }

        // GET api/<controller>/5        
        [HttpGet("{id}")]
        public string GetProduct(int id) 
        {
            return "value";
        }

        
        // POST api/<controller>
        [HttpPost]
        public IActionResult sdfsdfg(Product product) // automatic deserialization
        {
            try
            {
                _products.Add(product);
                return Ok(_products); // StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            try
            {
                var p = _products.Where(x => x.ProductId == id).FirstOrDefault();
                if (p != null)
                {
                    p.ProductName = product.ProductName;
                    p.ProductPrice = product.ProductPrice;
                    return Ok(_products);
                }

                return BadRequest($"there is no product for {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var p = _products.Where(x => x.ProductId == id).FirstOrDefault();
            if (p != null)
            {
                _products.Remove(p);
                 return Ok(_products);
            }
            return BadRequest($"there is no product for {id}");
        }
    }
}
