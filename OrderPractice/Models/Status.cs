using System;
using System.Collections.Generic;

namespace OrderPractice.Models
{
    public class Status
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public IList<Order> Orders { get; set; }
    }
}
