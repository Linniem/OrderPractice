using OrderPractice.Models;
using System.Threading.Tasks;

namespace OrderPractice.Services
{
    public interface IProductService
    {
        public Task<Product> FindProductAsync(string productName);
    }
}
