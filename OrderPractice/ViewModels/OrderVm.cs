namespace OrderPractice.ViewModels
{
    public class OrderVm
    {
        public string OrderId { get; set; }
        public int Price { get; set; }
        public int Cost { get; set; }

        public string ProductName { get; set; }
        public string StatusName { get; set; }
        public int StatusCode { get; set; }
    }
}
