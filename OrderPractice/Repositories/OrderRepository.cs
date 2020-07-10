using Microsoft.EntityFrameworkCore;
using OrderPractice.Data;
using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPractice.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderPracticeContext dbContext;
        public OrderRepository(OrderPracticeContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Order>> GetAllAsyc()
        {
            return await dbContext.Orders
                .Include("Product")
                .Include("Status")
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetAsync(string id)
        {
            return await dbContext.Orders
                .Include("Product")
                .Include("Status")
                .FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task UpdateAsync(Order order)
        {
            dbContext.Entry(order).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
