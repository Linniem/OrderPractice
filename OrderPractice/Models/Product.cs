using System.Collections.Generic;

namespace OrderPractice.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
