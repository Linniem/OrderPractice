using OrderPractice.Models;
using OrderPractice.ViewModels;
using System.Collections.Generic;

namespace OrderPractice.Helpers
{
    public interface IViewModelConverter
    {
        public OrderVm OrderConvertOne(Order order);
        public IEnumerable<OrderVm> OrderConvertAll(IEnumerable<Order> orderList);
    }
}