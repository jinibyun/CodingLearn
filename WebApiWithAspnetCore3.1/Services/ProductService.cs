using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public class ProductService : IProductService
    {
        IProduct repo;
        public ProductService()
        {
            repo = new ProductRepository();
        }

        public IQueryable<Product> GetProducts(decimal price)
        {
            // cache

            var products =  repo.GetProducts();

            return products.Where(x => x.ProductPrice > price);
        }

    }
}
