using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderPractice.Models;
using OrderPractice.Repositories;

namespace OrderPractice.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repo;
        public ProductService(IProductRepository repo)
        {
            this.repo = repo;
        }

        public async Task<Product> FindProduct(string productName)
        {
            return await repo.Find(x => x.ProductName == productName);
        }
    }
}
