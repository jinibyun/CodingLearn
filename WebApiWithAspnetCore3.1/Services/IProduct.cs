using System.Linq;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    public interface IProduct
    {
        IQueryable<Product> GetProducts();
        Product GetProduct(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(int id);
    }
}
