using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using OrderPractice.Models;
using OrderPractice.Services;
using OrderPractice.ViewModels;

namespace OrderPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderVm>>> GetOrder()
        {
            return Ok(await orderService.GetAllOrderVmAsync());
        }

        // GET: api/Orders/A20202026001
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderVm>> GetOrder(string id)
        {
            var orderVm = await orderService.GetOrderVmAsync(id);
            if (orderVm == null)
            {
                return NotFound();
            }
            return orderVm;
        }

        [HttpPatch("update/{id}")]
        public async Task<IActionResult> JsonPatchWithModelState(
               [FromBody] JsonPatchDocument<Order> patchDoc, string id)
        {
            if (patchDoc != null)
            {
                return await orderService.UpdateOrderAsync(patchDoc, id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}
