using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public interface IOrderRepository
    {
        public Task<IEnumerable<Order>> GetAllAsyc();
        public Task<Order> GetAsync(string id);
        public Task UpdateAsync(Order order);
    }
}
