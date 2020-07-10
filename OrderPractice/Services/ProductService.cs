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

        public async Task<Product> FindProductAsync(string productName)
        {
            return await repo.FindAsync(x => x.ProductName == productName);
        }
    }
}
