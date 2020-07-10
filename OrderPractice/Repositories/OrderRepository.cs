using Microsoft.EntityFrameworkCore;
using OrderPractice.Data;
using OrderPractice.Models;
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

        public IQueryable<Order> GetAll()
        {
            return dbContext.Orders
                .Include("Product")
                .Include("Status")
                .AsNoTracking();
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
