using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderPractice.Models;
using OrderPractice.Repositories;
using OrderPractice.ViewModels;
using OrderPractice.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OrderPractice.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repo;
        private readonly IViewModelConverter vmConverter;
        public OrderService(IOrderRepository orderRepository,IViewModelConverter vmConverter)
        {
            repo = orderRepository;
            this.vmConverter = vmConverter;
        }

        public async Task<IEnumerable<OrderVm>> GetAllOrderVmAsync()
        {
            var allOrders = await repo.GetAll().ToListAsync();
            return vmConverter.OrderConvertAll(allOrders);
        }

        public async Task<Order> GetOrderAsync(string orderId)
        {
            return await repo.GetAsync(orderId);
        }

        public async Task<OrderVm> GetOrderVmAsync(string orderId)
        {
            var order = await repo.GetAsync(orderId);
            return vmConverter.OrderConvertOne(order);
        }

        public async Task<IActionResult> UpdateOrderAsync(JsonPatchDocument<Order> patchDoc, string id)
        {
            var order = await GetOrderAsync(id);
            patchDoc.ApplyTo(order);

            await repo.UpdateAsync(order);

            return new ObjectResult(await GetOrderVmAsync(id));
        }
    }
}
