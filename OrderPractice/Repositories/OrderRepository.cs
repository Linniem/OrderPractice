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

        public async Task<List<Order>> GetAllAsync()
        {
            return await dbContext.Orders.Include("Product").Include("Status").ToListAsync();
        }

        public async Task<List<OrderVm>> GetAllVmAsync()
        {
            return await (from o in dbContext.Orders
                          join p in dbContext.Products on o.OrderProductId equals p.ProductId
                          join s in dbContext.Statuses on o.StatusCode equals s.StatusId
                          select new OrderVm
                          {
                              OrderId = o.OrderId,
                              Price = o.Price,
                              Cost = o.Cost,
                              ProductName = p.ProductName,
                              StatusCode = o.StatusCode,
                              StatusName = s.StatusName
                          }).ToListAsync();
        }

        public async Task<Order> GetAsync(string id)
        {
            return await dbContext.Orders.Include("Status").FirstOrDefaultAsync(x => x.OrderId == id);
        }

        public async Task<OrderVm> GetVmAsync(string id)
        {
            return await (from o in dbContext.Orders
                          join p in dbContext.Products on o.OrderProductId equals p.ProductId
                          join s in dbContext.Statuses on o.StatusCode equals s.StatusId
                          where o.OrderId == id
                          select new OrderVm
                          {
                              OrderId = o.OrderId,
                              Price = o.Price,
                              Cost = o.Cost,
                              ProductName = p.ProductName,
                              StatusCode = o.StatusCode,
                              StatusName = s.StatusName
                          }).FirstAsync();
        }

        public async Task Update(Order order)
        {
            dbContext.Entry(order).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
