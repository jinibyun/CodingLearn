using System.Collections.Generic;
using System.Linq;
using WebApiWithAspnetCore31.Data;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public class ProductRepository : IProduct
    {
        private ProductDbContext productsDbContext;
        public ProductRepository(ProductDbContext _productsDbContext)
        {
            productsDbContext = _productsDbContext;
        }
        public ProductRepository()
        {

        }

        public IQueryable<Product> GetProducts()
        {
            return productsDbContext.Products;
        }
        public Product GetProduct(int id)
        {
            var product = productsDbContext.Products.SingleOrDefault(m => m.ProductId == id);
            return product;
        }
        public void AddProduct(Product product)
        {
            try
            {
                productsDbContext.Products.Add(product);
                productsDbContext.SaveChanges(true);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateProduct(Product product)
        {
            productsDbContext.Products.Update(product);
            productsDbContext.SaveChanges(true);
        }
        public void DeleteProduct(int id)
        {
            var product = productsDbContext.Products.Find(id);
            productsDbContext.Products.Remove(product);
            productsDbContext.SaveChanges(true);
        }
    }
}
