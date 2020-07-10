using OrderPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPractice.Services
{
    public interface IProductService
    {
        public Task<Product> FindProduct(string productName);
    }
}
