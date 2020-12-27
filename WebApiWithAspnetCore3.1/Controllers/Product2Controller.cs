using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApiWithAspnetCore31.Models;
using WebApiWithAspnetCore31.Services;

namespace WebApiWithAspnetCore31.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Product2Controller : ControllerBase
    {
        private IProduct productRepository;

        // check built-in dependency injection on "Startup.cs"
        public Product2Controller(IProduct _product)
        {
            productRepository = _product;
        }

        // GET: api/Product2
        // 1. sorting: sortPrice
        // 2. paging: pageNumber, pageSize
        // 3. searching: searchProduct
        [HttpGet]
        public IEnumerable<Product> Get(int? pageNumber, int? pageSize, string sortPrice, string searchProduct)
        {
            IQueryable<Product> products;

            // searching
            if (!string.IsNullOrEmpty(searchProduct))
                products = productRepository.GetProducts().Where(x => x.ProductName.StartsWith(searchProduct));
            else
                products = productRepository.GetProducts();

            return products;

            // automatically, status will be returned "204: No Content"
            if (!products.Any())
                return null;
            // sorting
            switch (sortPrice)
            {
                case "desc":
                    products = products.OrderByDescending(p => p.ProductPrice);
                    break;
                case "asc":
                    products = products.OrderBy(p => p.ProductPrice);
                    break;
                //default:
                //    products = productDbContext.Products;
                //    break;

            }

            // paging
            int currentPage = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 3;
            // var items = products.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).ToList();

            // return items;
            // return products;
        }

        // GET: api/Product2/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = productRepository.GetProduct(id);
            if (product == null)
            {
                return NotFound("No record found...");
            }
            return Ok(product);
        }

        // POST: api/Product2
        [HttpPost]
        public IActionResult Post([FromBody]Product value)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            productRepository.AddProduct(value);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT: api/Product2/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(id != value.ProductId)
            {
                return BadRequest();
            }

            productRepository.UpdateProduct(value);

            return Ok(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            productRepository.DeleteProduct(id);
            return Ok("Product Deleted...");

        }
    }
}
