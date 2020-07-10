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

        // GET: api/Orders/5
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
                return await orderService.UpdateOrder(patchDoc, id);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        #region scaffolding
        //// PUT: api/Orders/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(string id, Order order)
        //{
        //    if (id != order.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    dbContext.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await dbContext.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Orders
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPost]
        //public async Task<ActionResult<Order>> PostOrder(Order order)
        //{
        //    dbContext.Orders.Add(order);
        //    await dbContext.SaveChangesAsync();

        //    return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        //}

        //// DELETE: api/Orders/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Order>> DeleteOrder(string id)
        //{
        //    var order = await dbContext.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    dbContext.Orders.Remove(order);
        //    await dbContext.SaveChangesAsync();

        //    return order;
        //}


        //private bool OrderExists(string id)
        //{
        //    return dbContext.Orders.Any(e => e.OrderId == id);
        //}
        #endregion
    }
}
