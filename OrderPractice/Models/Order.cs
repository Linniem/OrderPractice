using System.ComponentModel.DataAnnotations.Schema;

namespace OrderPractice.Models
{
    public class Order
    {
        public string OrderId { get; set; }
        public int Price { get; set; }
        public int Cost { get; set; }

        public int OrderProductId { get; set; }
        public int StatusCode { get; set; }

        [ForeignKey("OrderProductId")]
        public Product Product { get; set; }
        [ForeignKey("StatusCode")]
        public Status Status { get; set; }
    }
}
