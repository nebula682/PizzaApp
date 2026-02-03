using Microsoft.AspNetCore.Mvc;
using BlazingPizza.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlazingPizza.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrdersController : ControllerBase
    {
        // ✅ Fully qualified type
        private static readonly List<BlazingPizza.Model.Order> Orders = new();

        // GET /orders
        [HttpGet]
        public ActionResult<List<OrderWithStatus>> GetOrders()
        {
            var result = Orders
                .Select(BlazingPizza.Model.OrderWithStatus.FromOrder)
                .ToList();

            return Ok(result);
        }

        // GET /orders/{orderId}
        [HttpGet("{orderId:int}")]
        public ActionResult<OrderWithStatus> GetOrder(int orderId)
        {
            var order = Orders.FirstOrDefault(o => o.OrderId == orderId);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(BlazingPizza.Model.OrderWithStatus.FromOrder(order));
        }

        // POST /orders
        [HttpPost]
        public IActionResult PlaceOrder([FromBody] BlazingPizza.Model.Order order)
        {
            order.OrderId = Orders.Count + 1;
            Orders.Add(order);

            return Ok();
        }
    }
}