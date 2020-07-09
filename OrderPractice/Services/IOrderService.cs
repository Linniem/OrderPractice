using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderPractice.Services
{
    public interface IOrderService
    {
        public Task<List<Order>> GetAllOrderAsync();
        public Task<List<OrderVm>> GetAllOrderVmAsync();
        public Task<Order> GetOrderAsync(string orderId);
        public Task<OrderVm> GetOrderVmAsync(string orderId);
        public Task<IActionResult> UpdateOrder(JsonPatchDocument<Order> patchDoc, string id);
    }
}
