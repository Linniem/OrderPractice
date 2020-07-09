using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderPractice.Models;
using OrderPractice.Repositories;
using OrderPractice.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderPractice.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository repo;

        public OrderService(IOrderRepository orderRepository)
        {
            repo = orderRepository;
        }

        public async Task<List<Order>> GetAllOrderAsync()
        {
            //var orders = await repo.GetAllAsync();
            //return ConvertToViewModel(orders);

            return await repo.GetAllAsync();
        }

        public async Task<List<OrderVm>> GetAllOrderVmAsync()
        {
            return await repo.GetAllVmAsync();
        }

        public async Task<Order> GetOrderAsync(string orderId)
        {
            return await repo.GetAsync(orderId);
        }

        public async Task<OrderVm> GetOrderVmAsync(string orderId)
        {
            return await repo.GetVmAsync(orderId);
        }

        public async Task<IActionResult> UpdateOrder(JsonPatchDocument<Order> patchDoc, string id)
        {
            var order = await GetOrderAsync(id);
            patchDoc.ApplyTo(order);

            await repo.Update(order);

            var newOrderVm = await GetOrderVmAsync(id);

            return new ObjectResult(newOrderVm);
        }

        // unused below
        private List<OrderVm> ConvertToViewModel(IEnumerable<Order> orders)
        {
            var orderVmList = new List<OrderVm>();
            foreach (var order in orders)
            {
                var newOrderVm = new OrderVm()
                {
                    ProductName = order.Product.ProductName,
                    StatusName = order.Status.StatusName
                };
                CopyProperties(order, newOrderVm);
                orderVmList.Add(newOrderVm);
            }
            return orderVmList;
        }

        private void CopyProperties<T, TU>(T source, TU dest)
        {
            var sourceProps = typeof(T).GetProperties().Where(x => x.CanRead).ToList();
            var destProps = typeof(TU).GetProperties().Where(x => x.CanWrite).ToList();

            foreach (var sourceProp in sourceProps)
            {
                if (destProps.Any(x => x.Name == sourceProp.Name))
                {
                    var p = destProps.First(x => x.Name == sourceProp.Name);
                    if (p.CanWrite)
                    {
                        // check if the property can be set or no.
                        p.SetValue(dest, sourceProp.GetValue(source, null), null);
                    }
                }
            }
        }
    }
}
