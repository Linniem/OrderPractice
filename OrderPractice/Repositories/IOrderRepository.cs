using OrderPractice.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public interface IOrderRepository
    {
        public IQueryable<Order> GetAll();
        public Task<Order> GetAsync(string id);
        public Task UpdateAsync(Order order);
    }
}
