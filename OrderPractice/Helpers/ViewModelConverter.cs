using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;

namespace OrderPractice.Helpers
{
    public class ViewModelConverter : IViewModelConverter
    {
        public OrderVm OrderConvertOne(Order order)
        {
            return new OrderVm()
            {
                OrderId = order.OrderId,
                Price = order.Price,
                Cost = order.Cost,
                ProductName = order.Product.ProductName,
                StatusName = order.Status.StatusName,
                StatusCode = order.StatusCode
            };
        }
        
        public IEnumerable<OrderVm> OrderConvertAll(IEnumerable<Order> orderList)
        {
            foreach (var order in orderList)
            {
                yield return OrderConvertOne(order);
            }
        }

    }
}