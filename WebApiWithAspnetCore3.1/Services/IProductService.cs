using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWithAspnetCore31.Models;

namespace WebApiWithAspnetCore31.Services
{
    interface IProductService
    {
        IQueryable<Product> GetProducts(decimal price);
    }
}
