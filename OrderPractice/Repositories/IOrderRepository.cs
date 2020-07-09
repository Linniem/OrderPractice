using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public interface IOrderRepository
    {
        public Task<List<Order>> GetAllAsync();
        public Task<List<OrderVm>> GetAllVmAsync();
        public Task<Order> GetAsync(string id);
        public Task<OrderVm> GetVmAsync(string id);
        public Task Update(Order order);
    }
}
